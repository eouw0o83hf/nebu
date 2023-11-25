using Microsoft.EntityFrameworkCore;

namespace Nebu.Api.Ef;

public class NebuContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<EfUser> Users { get; set; }
}
