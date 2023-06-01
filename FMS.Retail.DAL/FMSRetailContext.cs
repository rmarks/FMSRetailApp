using FMS.Retail.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace FMS.Retail.DAL;

public class FMSRetailContext : DbContext
{
    public FMSRetailContext(DbContextOptions<FMSRetailContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Sale> Sales { get; set; }
}
