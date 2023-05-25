using FMS.Retail.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace FMS.Retail.DAL;

public class FMSRetailContext : DbContext
{
    public FMSRetailContext(DbContextOptions<FMSRetailContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}
