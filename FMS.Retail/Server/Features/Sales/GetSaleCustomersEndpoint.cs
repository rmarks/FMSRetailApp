using Ardalis.ApiEndpoints;
using FMS.Retail.DAL;
using FMS.Retail.Shared.Features.Sales;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FMS.Retail.Server.Features.Sales;

public class GetSaleCustomersEndpoint : EndpointBaseAsync.WithRequest<string>.WithActionResult<IEnumerable<CustomerModel>>
{
    private readonly FMSRetailContext _context;

    public GetSaleCustomersEndpoint(FMSRetailContext context)
    {
        _context = context;
    }

    [HttpGet("/api/sale/customers/search/{customerName}")]
    public override async Task<ActionResult<IEnumerable<CustomerModel>>> HandleAsync(string customerName, CancellationToken cancellationToken = default)
    {
        return await _context.Customers
            .AsNoTracking()
            .Where(c => c.Name.Contains(customerName, StringComparison.OrdinalIgnoreCase))
            .Select(c => new CustomerModel
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToListAsync();
    }
}
