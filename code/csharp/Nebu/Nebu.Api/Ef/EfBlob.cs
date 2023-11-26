using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Nebu.Api.Ef;

[Table("Blobs")]
[Index(nameof(BucketId), nameof(Key), IsUnique = true)]
public class EfBlob
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public Guid BucketId { get; set; }
    public EfBucket? Bucket { get; set; }

    public Guid Key { get; set; }
    public required string Filename { get; set; }
    public required long SizeBytes { get; set; }
}
