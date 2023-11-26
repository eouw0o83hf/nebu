using Microsoft.EntityFrameworkCore;
using Nebu.Api.Ef;
using Nebu.Api.Models.Blobs;

namespace Nebu.Api.Services;

public class BlobService(NebuContext _db) : IBlobService
{
    public async Task<BlobReadModel> CreateBlob(Guid bucketId, BlobWriteModel m)
    {
        var b = await _db.Set<EfBlob>()
            .AddAsync(new EfBlob
            {
                BucketId = bucketId,
                Key = m.Key!
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

    private static BlobReadModel ToReadModel(EfBlob b)
        => new(b.Id, b.BucketId, b.Key);
}
