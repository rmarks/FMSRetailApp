using Ardalis.ApiEndpoints;
using FMS.Retail.DAL;
using FMS.Retail.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Retail.Server.Features.Products;

public class DeleteProductEndpoint : EndpointBaseAsync.WithRequest<int>.WithActionResult
{
    private readonly FMSRetailContext _context;

    public DeleteProductEndpoint(FMSRetailContext context)
    {
        _context = context;
    }

    [HttpDelete("/product/{id}")]
    public override async Task<ActionResult> HandleAsync(int id, CancellationToken cancellationToken = default)
    {
        Product? productToDelete = await _context.Products.FindAsync(id, cancellationToken);

        if (productToDelete is null)
        {
            return BadRequest("Product could not be found.");
        }

        _context.Remove(productToDelete);
        await _context.SaveChangesAsync();

        return Ok();
    }
}
