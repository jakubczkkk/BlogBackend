using Microsoft.EntityFrameworkCore;
using BlogBackend.Models;

namespace BlogBackend.Controllers 
{
    public class BlogDbContext : DbContext
    {

        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

    }
}