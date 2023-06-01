using Ardalis.ApiEndpoints;
using FMS.Retail.DAL;
using FMS.Retail.Shared.Features.Sales;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FMS.Retail.Server.Features.Sales;

public class GetSalesEndpoint : EndpointBaseAsync.WithoutRequest.WithActionResult<IEnumerable<SalesListItemModel>>
{
    private readonly FMSRetailContext _context;

    public GetSalesEndpoint(FMSRetailContext context)
    {
        _context = context;
    }

    [HttpGet("/api/sales")]
    public override async Task<ActionResult<IEnumerable<SalesListItemModel>>> HandleAsync(CancellationToken cancellationToken = default)
    {
        var sales = await _context.Sales
            .AsNoTracking()
            .Select(s => new SalesListItemModel
            {
                Id = s.Id,
                SaleNo = s.SaleNo,
                SaleDate = s.SaleDate,
                CustomerName = s.Customer.Name
            })
            .ToListAsync();

        return Ok(sales);
    }
}
