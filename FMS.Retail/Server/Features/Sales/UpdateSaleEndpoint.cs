using Ardalis.ApiEndpoints;
using FMS.Retail.DAL;
using FMS.Retail.Domain.Model;
using FMS.Retail.Shared.Features.Sales;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FMS.Retail.Server.Features.Sales;

public class UpdateSaleEndpoint : EndpointBaseAsync.WithRequest<SaleModel>.WithActionResult
{
    private readonly FMSRetailContext _context;

    public UpdateSaleEndpoint(FMSRetailContext context)
    {
        _context = context;
    }

    [HttpPut("/api/sale")]
    public override async Task<ActionResult> HandleAsync(SaleModel model, CancellationToken cancellationToken = default)
    {
        Sale? entity = await _context.Sales.Include(s => s.Items).FirstOrDefaultAsync(s => s.Id == model.Id);
        
        if (entity == null) return BadRequest("Sale not found");

        if (entity.CustomerId != model.Customer?.Id)
        {
            entity.CustomerId = model.Customer?.Id;
        }

        _context.Entry(entity).CurrentValues.SetValues(model);

        foreach (var entityItem in entity.Items)
        {
            if (!model.Items.Any(i => i.Id == entityItem.Id))
            {
                _context.Remove(entityItem);
            }
        }

        foreach (var modelItem in model.Items)
        {
            var entityItem = entity.Items.FirstOrDefault(i => i.Id == modelItem.Id);
            if (entityItem == null)
            {
                SaleItem newItem = new();
                _context.Entry(newItem).CurrentValues.SetValues(modelItem);
                entity.Items.Add(newItem);
            }
            else
            {
                _context.Entry(entityItem).CurrentValues.SetValues(modelItem);
            }
        }

        await _context.SaveChangesAsync();

        return Ok();
    }
}
