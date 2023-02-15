using Microsoft.EntityFrameworkCore;
using az_sql_ad_auth.Models;

namespace az_sql_ad_auth.DAL;

public class AdwContext : DbContext
{
    public AdwContext (DbContextOptions<AdwContext> options)
        : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("SalesLT");
        modelBuilder.Entity<Customer>().ToTable("Customer");
    }
}
