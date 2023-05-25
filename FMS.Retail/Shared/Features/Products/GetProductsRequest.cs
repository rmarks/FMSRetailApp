namespace FMS.Retail.Shared.Features.Products;

public record GetProductsRequest(int PageNo, int PageSize)
{
    public record Response(IEnumerable<ProductListItemModel> PagedList, int PageCount);
}
