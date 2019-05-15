using GraphQLDemoAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemoAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
