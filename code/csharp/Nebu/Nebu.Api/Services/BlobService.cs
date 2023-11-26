using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Minio;
using Minio.DataModel.Args;
using Nebu.Api.Ef;
using Nebu.Api.Models.Blobs;
using File = Nebu.Api.Models.Blobs.File;

namespace Nebu.Api.Services;

public class BlobService(NebuContext _db, IMinioClientFactory _minio) : IBlobService
{
    public async Task<BlobReadModel> CreateBlob(Guid bucketId, string filename, long size, Stream data)
    {
        var key = Guid.NewGuid();
        var args = new PutObjectArgs()
            .WithBucket("temp")
            .WithObject(key.ToString())
            .WithObjectSize(size)
            .WithStreamData(data);

        using var m = resolveClient();
        var result = await m.PutObjectAsync(args).ConfigureAwait(false);

        var b = await _db.Set<EfBlob>()
            .AddAsync(new EfBlob
            {
                BucketId = bucketId,
                Key = key,
                Filename = filename,
                SizeBytes = size
            });
        await _db.SaveChangesAsync();

        return ToReadModel(b.Entity);
    }

    public async Task<IEnumerable<BlobReadModel>> ListBlobs(Guid bucketId)
    {
        return await _db.Set<EfBlob>()
            .Where(b => b.BucketId == bucketId)
            .Select(b => ToReadModel(b))
            .ToListAsync();
    }

    public async Task<File> GetBlobFile(Guid bucketId, Guid blobId)
    {
        var b = await _db.Set<EfBlob>()
            .SingleOrDefaultAsync(b => b.BucketId == bucketId && b.Id == blobId);
        if (b == null)
        {
            throw new Exception("Blob not found");
        }

        using var m = resolveClient();
        var stream = new MemoryStream((int)b.SizeBytes);
        var args = new GetObjectArgs()
            .WithBucket("temp")
            .WithObject(b.Key.ToString())
            .WithCallbackStream(s => s.CopyTo(stream));

        await m.GetObjectAsync(args).ConfigureAwait(false);

        stream.Position = 0;
        return new File(b.Filename, stream);
    }

    private IMinioClient resolveClient()
    {
        // temporary non-sensitive local values
        var creds = new
        {
            Key = "3PEZwSncibPRafAEVVqE",
            Secret = "zWQSfoxyxTldqQJuwcCK7nF2ii6n25AzFevDcH7W",
            Bucket = "temp",
            Endpoint = "localhost:9000"
        };

        return _minio.CreateClient(cfg => cfg
                .WithCredentials(creds.Key, creds.Secret)
                .WithEndpoint(creds.Endpoint))
                .WithSSL(false);
    }

    private static BlobReadModel ToReadModel(EfBlob b)
        => new(b.Id, b.BucketId, b.Key, b.Filename, b.SizeBytes);
}
