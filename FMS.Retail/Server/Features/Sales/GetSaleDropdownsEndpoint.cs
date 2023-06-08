using Ardalis.ApiEndpoints;
using FMS.Retail.DAL;
using FMS.Retail.Shared.Features.Sales;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FMS.Retail.Server.Features.Sales;

public class GetSaleDropdownsEndpoint : EndpointBaseAsync.WithoutRequest.WithActionResult<GetSaleDropdownsResponse>
{
    private readonly FMSRetailContext _context;

    public GetSaleDropdownsEndpoint(FMSRetailContext context)
    {
        _context = context;
    }

    [HttpGet("/api/sale/dropdowns")]
    public override async Task<ActionResult<GetSaleDropdownsResponse>> HandleAsync(CancellationToken cancellationToken = default)
    {
        var paymentTypes = await _context.PaymentTypes
            .AsNoTracking()
            .Select(pt => new PaymentTypeModel
            {
                Id = pt.Id,
                Name = pt.Name
            })
            .ToListAsync();

        var customerTypes = await _context.CustomerTypes
            .AsNoTracking()
            .Select(ct => new CustomerTypeModel
            {
                Id = ct.Id,
                Name = ct.Name,
                HasCustomer = ct.HasCustomer
            })
            .ToListAsync();

        return Ok(new GetSaleDropdownsResponse(paymentTypes, customerTypes));
    }
}
