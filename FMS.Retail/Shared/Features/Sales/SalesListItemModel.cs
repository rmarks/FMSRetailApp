namespace FMS.Retail.Shared.Features.Sales;

public class SalesListItemModel
{
    public int Id { get; set; }
    public string SaleNo { get; set; } = string.Empty;
    public DateTime? SaleDate { get; set; }
    public string CustomerTypeName { get; set; } = string.Empty;
    public string PaymentTypeName { get; set; } = string.Empty;
}
