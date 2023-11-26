namespace Nebu.Api.Models.Buckets;

public interface IBucketService
{
    Task<IEnumerable<BucketReadModel>> ListBuckets(Guid userId);
    Task<BucketReadModel> CreateBucket(Guid userId, BucketWriteModel m);
}
