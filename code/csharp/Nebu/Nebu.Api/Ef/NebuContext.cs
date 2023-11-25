using Microsoft.EntityFrameworkCore;

namespace Nebu.Api.Ef
{
    public class NebuContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }

    public class User
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}
