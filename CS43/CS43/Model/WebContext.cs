using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CS43.Model;

public class WebContext : DbContext
{
    public DbSet<Article> Articles { set; get; }
    public DbSet<Tag> Tags { set; get; }
    public DbSet<ArticleTag> ArticleTags { set; get; }

    private const string connectString =
        "Data Source=localhost,1433;Initial Catalog=shopdata;Integrated Security=True;User ID=sa;Password=Password12;TrustServerCertificate=True;";

    public static readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
        builder.AddFilter(DbLoggerCategory.Database.Name, LogLevel.Information);
        builder.AddConsole();
    });

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(connectString);
        optionsBuilder.UseLoggerFactory(_loggerFactory);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ArticleTag>(e => { e.HasIndex(at => new { at.ArticleId, at.TagId }).IsUnique(); });
    }
}