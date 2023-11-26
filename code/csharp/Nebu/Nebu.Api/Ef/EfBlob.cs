using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nebu.Api.Ef;

[Table("Blobs")]
public class EfBlob
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public Guid BucketId { get; set; }
    public EfBucket? Bucket { get; set; }

    public required string Key { get; set; }
}
