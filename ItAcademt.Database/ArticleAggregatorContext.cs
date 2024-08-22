using ItAcademy.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace ItAcademy.Database;

public class ArticleAggregatorContext : DbContext
{
    public DbSet<Article?> Articles { get; set; }
    public DbSet<Source> Sources { get; set; }
    public DbSet<Role> Roles{ get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    public ArticleAggregatorContext(DbContextOptions<ArticleAggregatorContext> options) 
        : base(options)
    {

    }
}