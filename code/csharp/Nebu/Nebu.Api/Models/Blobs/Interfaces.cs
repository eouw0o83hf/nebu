namespace Nebu.Api.Models.Blobs;

public interface IBlobService
{
    Task<IEnumerable<BlobReadModel>> ListBlobs(Guid bucketId);
    Task<BlobReadModel> CreateBlob(Guid bucketId, BlobWriteModel m);
}
