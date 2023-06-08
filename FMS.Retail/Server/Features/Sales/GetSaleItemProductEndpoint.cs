using Ardalis.ApiEndpoints;
using FMS.Retail.DAL;
using FMS.Retail.Shared.Features.Sales;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FMS.Retail.Server.Features.Sales;

public class GetSaleItemProductEndpoint : EndpointBaseAsync.WithRequest<string>.WithActionResult<SaleItemProductModel>
{
    private readonly FMSRetailContext _context;

    public GetSaleItemProductEndpoint(FMSRetailContext context)
    {
        _context = context;
    }

    [HttpGet("/api/saleitem/product/{productCode}")]
    public override async Task<ActionResult<SaleItemProductModel>> HandleAsync(string productCode, CancellationToken cancellationToken = default)
    {
        var model = await _context.Products
            .AsNoTracking()
            .Where(p => p.Code == productCode)
            .Select(p => new SaleItemProductModel
            {
                ProductId = p.Id,
                ProductCode = p.Code,
                ProductName = p.Name,
                ProductPrice = p.Price
            })
            .FirstOrDefaultAsync();

        if (model == null) return NotFound();

        return Ok(model);
    }
}
