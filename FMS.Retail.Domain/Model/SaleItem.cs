namespace FMS.Retail.Domain.Model;

public class SaleItem
{
    public int Id { get; set; }
    
    public int SaleId { get; set; }
    
    public int ProductId { get; set; }
    public Product Product { get; set; } = default!;

    public int Quantity { get; set; }
}
