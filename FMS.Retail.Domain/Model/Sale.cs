namespace FMS.Retail.Domain.Model;

public class Sale
{
    public int Id { get; set; }
    
    public string SaleNo { get; set; } = default!;
    public DateTime? SaleDate { get; set; }
    
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = default!;
}
