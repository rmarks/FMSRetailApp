using Ardalis.ApiEndpoints;
using FMS.Retail.DAL;
using FMS.Retail.Shared.Features.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FMS.Retail.Server.Features.Products;

public class GetProductEndpoint : EndpointBaseAsync.WithRequest<int>.WithActionResult<ProductModel>
{
    private readonly FMSRetailContext _context;

    public GetProductEndpoint(FMSRetailContext context)
    {
        _context = context;
    }

    [HttpGet("/product/{id}")]
    public override async Task<ActionResult<ProductModel>> HandleAsync(int id, CancellationToken cancellationToken = default)
    {
        var model = await _context.Products
            .AsNoTracking()
            .Where(p  => p.Id == id)
            .Select(p => new ProductModel
            {
                Id = p.Id,
                Code = p.Code,
                Name = p.Name,
                Price = p.Price
            })
            .FirstOrDefaultAsync();

        return model is not null ? Ok(model) : BadRequest("Product could not be found.");
    }
}
