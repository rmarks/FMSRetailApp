using Ardalis.ApiEndpoints;
using FMS.Retail.DAL;
using FMS.Retail.Domain.Model;
using FMS.Retail.Shared.Features.Sales;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Retail.Server.Features.Sales;

public class AddSaleEndpoint : EndpointBaseAsync.WithRequest<SaleModel>.WithActionResult<int>
{
    private readonly FMSRetailContext _context;

    public AddSaleEndpoint(FMSRetailContext context)
    {
        _context = context;
    }

    [HttpPost("/api/sale")]
    public override async Task<ActionResult<int>> HandleAsync(SaleModel saleModel, CancellationToken cancellationToken = default)
    {
        Sale sale = new Sale
        {
            SaleNo = GetNextNo(),
            SaleDate = DateTime.Now,
            CustomerTypeId = saleModel.CustomerTypeId,
            CustomerId = saleModel.Customer?.Id,
            PaymentTypeId = saleModel.PaymentTypeId
        };

        await _context.AddAsync(sale);

        List<SaleItem> items = saleModel.Items.Select(i => new SaleItem
        {
            SaleId = sale.Id,
            ProductId = i.ProductId,
            Quantity = i.Quantity
        }).ToList();

        await _context.AddRangeAsync(items);

        await _context.SaveChangesAsync();

        return Ok(sale.Id);
    }

    private string GetNextNo()
    {
        int lastNo = _context.Sales.Count();

        return lastNo == 0 ? "1" : (lastNo + 1).ToString();
    }
}
