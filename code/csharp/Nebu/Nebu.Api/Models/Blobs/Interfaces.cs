namespace Nebu.Api.Models.Blobs;

public interface IBlobService
{
    Task<IEnumerable<BlobReadModel>> ListBlobs(Guid bucketId);
    Task<File> GetBlobFile(Guid bucketId, Guid blobId);

    Task<BlobReadModel> CreateBlob(Guid bucketId, string filename, long size, Stream data);
}
