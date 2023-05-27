using Ardalis.ApiEndpoints;
using FMS.Retail.DAL;
using FMS.Retail.Shared.Features.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FMS.Retail.Server.Features.Products;

public class GetProductsEndpoint : EndpointBaseAsync.WithRequest<GetProductsRequest>.WithActionResult<GetProductsRequest.Response>
{
    private readonly FMSRetailContext _context;

    public GetProductsEndpoint(FMSRetailContext context)
    {
        _context = context;
    }

    [HttpGet("/api/products")]
    public override async Task<ActionResult<GetProductsRequest.Response>> HandleAsync([FromQuery] GetProductsRequest request, CancellationToken cancellationToken = default)
    {
        var query = _context.Products
            .AsNoTracking();

        if (request.SearchTerm is not null)
        {
            query = query.Where(p => p.Code.StartsWith(request.SearchTerm, StringComparison.OrdinalIgnoreCase));
        }

        int pageCount = (int)Math.Ceiling((decimal)query.Count() / request.PageSize);

        var products = await query
            .OrderBy(p => p.Code)
            .Skip((request.PageNo - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(p => new ProductListItemModel
            {
                Id = p.Id,
                Code = p.Code,
                Name = p.Name,
                Price = p.Price
            })
            .ToListAsync();

        return Ok(new GetProductsRequest.Response(products, pageCount));
    }
}
