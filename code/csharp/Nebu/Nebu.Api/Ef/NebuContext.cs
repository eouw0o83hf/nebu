using Microsoft.EntityFrameworkCore;

namespace Nebu.Api.Ef;

public class NebuContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<EfUser> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EfUser>()
            .HasMany(a => a.Buckets)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId)
            .HasPrincipalKey(a => a.Id)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<EfBucket>()
            .HasMany(a => a.Blobs)
            .WithOne(a => a.Bucket)
            .HasForeignKey(a => a.BucketId)
            .HasPrincipalKey(a => a.Id)
            .OnDelete(DeleteBehavior.NoAction);

        base.OnModelCreating(modelBuilder);
    }
}
