using System;
using Microsoft.EntityFrameworkCore;

namespace HotChocolatePostgres.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; } = default!;
    }
}
