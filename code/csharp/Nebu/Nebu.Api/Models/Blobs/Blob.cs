using System.ComponentModel.DataAnnotations;

namespace Nebu.Api.Models.Blobs;

public record BlobReadModel(
    Guid Id,
    Guid BucketId,
    Guid Key,
    string Filename,
    long SizeBytes)
{ }

public record BlobWriteModel
{
    [Required]
    public IFormFile? File { get; set; }
}

public record File(
    string Filename,
    Stream Content)
{ }
