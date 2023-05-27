using Ardalis.ApiEndpoints;
using FMS.Retail.DAL;
using FMS.Retail.Domain.Model;
using FMS.Retail.Shared.Features.Products;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Retail.Server.Features.Products;

public class AddProductEndpoint : EndpointBaseAsync.WithRequest<ProductModel>.WithActionResult
{
    private readonly FMSRetailContext _context;

    public AddProductEndpoint(FMSRetailContext context)
    {
        _context = context;
    }

    [HttpPost("/product")]
    public override async Task<ActionResult> HandleAsync(ProductModel model, CancellationToken cancellationToken = default)
    {
        Product product = new Product
        {
            Code = model.Code,
            Name = model.Name,
            Price = model.Price
        };

        await _context.AddAsync(product);
        await _context.SaveChangesAsync();

        return Ok();
    }
}
