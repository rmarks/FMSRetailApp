namespace FMS.Retail.Shared.Features.Sales;

public class SaleItemProductModel
{
    public int ProductId { get; set; }
    public string ProductCode { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public decimal ProductPrice { get; set; }
}
