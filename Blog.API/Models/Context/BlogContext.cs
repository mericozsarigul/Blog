using Blog.Model.Data;
using Microsoft.EntityFrameworkCore;


namespace Blog.API.Models.Context
{
    public class BlogContext: DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {
        }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
