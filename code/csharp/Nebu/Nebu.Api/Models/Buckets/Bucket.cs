using System.ComponentModel.DataAnnotations;

namespace Nebu.Api.Models.Buckets;

public record BucketReadModel(
    Guid Id,
    Guid UserId,
    string Uri
)
{ }

public class BucketWriteModel
{
    [Required]
    public string? Uri { get; set; }
}
