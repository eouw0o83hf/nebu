using Microsoft.EntityFrameworkCore;
using Nebu.Api.Ef;
using Nebu.Api.Models.Buckets;

namespace Nebu.Api.Services;

public class BucketService(NebuContext _db) : IBucketService
{
    public async Task<BucketReadModel> CreateBucket(Guid userId, BucketWriteModel m)
    {
        var b = await _db.Set<EfBucket>()
            .AddAsync(new EfBucket
            {
                UserId = userId,
                Uri = m.Uri!
            });
        await _db.SaveChangesAsync();

        return ToReadModel(b.Entity);
    }

    public async Task<IEnumerable<BucketReadModel>> ListBuckets(Guid userId)
    {
        return await _db.Set<EfBucket>()
            .Where(b => b.UserId == userId)
            .Select(a => ToReadModel(a))
            .ToListAsync();
    }

    private static BucketReadModel ToReadModel(EfBucket b)
        => new(b.Id, b.UserId, b.Uri);
}
