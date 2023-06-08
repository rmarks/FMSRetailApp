using Ardalis.ApiEndpoints;
using FMS.Retail.DAL;
using FMS.Retail.Shared.Features.Sales;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FMS.Retail.Server.Features.Sales;

public class GetSaleEndpoint : EndpointBaseAsync.WithRequest<int>.WithActionResult<SaleModel>
{
    private readonly FMSRetailContext _context;

    public GetSaleEndpoint(FMSRetailContext context)
    {
        _context = context;
    }

    [HttpGet("/api/sale/{id}")]
    public override async Task<ActionResult<SaleModel>> HandleAsync(int id, CancellationToken cancellationToken = default)
    {
        var sale = await _context.Sales
            .AsNoTracking()
            .Where(s => s.Id == id)
            .Select(s => new  SaleModel 
            { 
                Id = s.Id,
                SaleNo = s.SaleNo,
                SaleDate = s.SaleDate,
                Customer = s.Customer == null ? null : new CustomerModel { Id = s.Customer.Id, Name = s.Customer.Name },
                PaymentTypeId = s.PaymentTypeId,
                CustomerTypeId = s.CustomerTypeId,
                Items = s.Items.OrderBy(i => i.Product.Code).Select(i => new SaleItemModel 
                { 
                    Id = i.Id,
                    SaleId = i.SaleId,
                    ProductId = i.ProductId,
                    ProductCode = i.Product.Code,
                    ProductName = i.Product.Name,
                    ProductPrice = i.Product.Price,
                    Quantity = i.Quantity
                })
                .ToList()
            })
            .FirstOrDefaultAsync();
        
        return Ok(sale);
    }
}
