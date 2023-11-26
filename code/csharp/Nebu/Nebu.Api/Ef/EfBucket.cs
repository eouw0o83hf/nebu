using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nebu.Api.Ef;

[Table("Buckets")]
public class EfBucket
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    public EfUser? User { get; set; }

    public required string Uri { get; set; }

    public ICollection<EfBlob>? Blobs { get; set; }
}
