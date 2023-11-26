using System.ComponentModel.DataAnnotations;

namespace Nebu.Api.Models.Blobs;

public record BlobReadModel(
    Guid Id,
    Guid BucketId,
    string Key)
{
}

public record BlobWriteModel
{
    [Required]
    public string? Key { get; set; }
}
