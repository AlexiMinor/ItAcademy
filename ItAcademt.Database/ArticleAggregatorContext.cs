using ItAcademy.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace ItAcademy.Database;

public class ArticleAggregatorContext : DbContext
{
    public DbSet<Article?> Articles { get; set; }

    public ArticleAggregatorContext(DbContextOptions<ArticleAggregatorContext> options) 
        : base(options)
    {

    }
}