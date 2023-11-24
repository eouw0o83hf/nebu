using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Nebu.Api.Ef
{
    public class NebuContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public NebuContext(DbContextOptions options) : base(options) { }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //     => optionsBuilder.UseNpgsql("Host=my_host;Database=my_db;Username=my_user;Password=my_pw");
    }

    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
