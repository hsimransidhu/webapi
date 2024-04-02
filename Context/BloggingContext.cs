using webapi.Models;
namespace webapi.Data;
using Microsoft.EntityFrameworkCore;

public class BloggingContext : DbContext
{
    public BloggingContext(DbContextOptions<BloggingContext> options)
        : base(options)
    {

    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer(@"Server =.; Database=LibraryManagement;Trusted_Connection=True;TrustServerCertificate=True;");


    //}
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
}

