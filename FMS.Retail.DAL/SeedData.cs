using FMS.Retail.Domain.Model;
using Microsoft.Extensions.DependencyInjection;

namespace FMS.Retail.DAL;

public static class SeedData
{
    public static void EnsurePopulated(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<FMSRetailContext>();
        
        context.Database.EnsureCreated();

        if (context.Products.Any()) return;

        context.Products.AddRange(new[]
        {
            new Product { Code = "00020073", Name = "Sõrmus nat. safiir", Price = 230 },
            new Product { Code = "00020282", Name = "Sõrmus naturaalne safiir, teemant", Price = 420 },
            new Product { Code = "00020355", Name = "Sõrmus naturaalne granaat", Price = 350 },
            new Product { Code = "00020446", Name = "Sõrmus pärl valge", Price = 160 },
            new Product { Code = "00020616", Name = "Sõrmus nat. granaat", Price = 320 },
            new Product { Code = "00020829", Name = "Sõrmus naturaalne granaat", Price = 370 },
            new Product { Code = "00021477", Name = "Sõrmus valge pärl", Price = 190 },
            new Product { Code = "00021526", Name = "Sõrmus naturaalne smaragd", Price = 330 },
            new Product { Code = "00021679", Name = "Sõrmus nat. topaas", Price = 270 },
            new Product { Code = "00022261", Name = "Sõrmus nat. granaat", Price = 295 },
            new Product { Code = "03020916", Name = "Sõrmus sünt. aleksandriit", Price = 140 },
            new Product { Code = "03021035", Name = "Sõrmus CZ must", Price = 170 },
            new Product { Code = "03021717", Name = "Sõrmus sünt. ametüst", Price = 150 },
            new Product { Code = "03022187", Name = "Sõrmus CZ", Price = 160 },
            new Product { Code = "03022335", Name = "Sõrmus sünt. aleksandriit", Price = 150 },
            new Product { Code = "03030232", Name = "Kõrvarõngad CZ valge", Price = 180 },
            new Product { Code = "03030796", Name = "Kõrvarõngad CZ valge", Price = 180 },
            new Product { Code = "03031077", Name = "Kõrvarõngad CZ shampanja", Price = 190 },
            new Product { Code = "03031752", Name = "Kõrvarõngad CZ sampanja", Price = 200 },
            new Product { Code = "03031528", Name = "Kõrvarõngad CZ", Price = 210 },
            new Product { Code = "03090239", Name = "Ripats CZ sinine", Price = 140 },
            new Product { Code = "03090662", Name = "Ripats sünt. aleksandriit", Price = 120 },
            new Product { Code = "03090797", Name = "Ripats CZ valge", Price = 90 },
            new Product { Code = "03090820", Name = "Ripats CZ valge", Price = 80 },
            new Product { Code = "03092347", Name = "Ripats CZ lavender", Price = 85 },
            new Product { Code = "03092477", Name = "Ripats CZ", Price = 70 },
            new Product { Code = "03098704", Name = "Ripats Hobuseraud CZ", Price = 60 }
        });

        context.Customers.Add(new Customer { Name = "Jaemüügi klient" });

        context.SaveChanges();

        context.Sales.AddRange(new[]
        {
            new Sale { SaleNo = "1", SaleDate = new DateTime(2023, 5, 29), CustomerId = 1 },
            new Sale { SaleNo = "2", SaleDate = new DateTime(2023, 5, 30), CustomerId = 1 },
            new Sale { SaleNo = "3", SaleDate = new DateTime(2023, 5, 31), CustomerId = 1 }
        });

        context.SaveChanges();
    }
}
