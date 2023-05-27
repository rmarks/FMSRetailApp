using Ardalis.ApiEndpoints;
using FMS.Retail.DAL;
using FMS.Retail.Domain.Model;
using FMS.Retail.Shared.Features.Products;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Retail.Server.Features.Products;

public class UpdateProductEndpoint : EndpointBaseAsync.WithRequest<ProductModel>.WithActionResult
{
    private readonly FMSRetailContext _context;

    public UpdateProductEndpoint(FMSRetailContext context)
    {
        _context = context;
    }

    [HttpPut("/product")]
    public override async Task<ActionResult> HandleAsync(ProductModel model, CancellationToken cancellationToken = default)
    {
        Product? productToUpdate = await _context.Products.FindAsync(model.Id, cancellationToken);
        
        if (productToUpdate is null)
        {
            return BadRequest("Product could not be found.");
        }

        _context.Entry(productToUpdate).CurrentValues.SetValues(model);
        await _context.SaveChangesAsync();

        return Ok();
    }
}
