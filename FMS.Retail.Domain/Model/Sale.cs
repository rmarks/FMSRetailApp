namespace FMS.Retail.Domain.Model;

public class Sale
{
    public int Id { get; set; }
    
    public string SaleNo { get; set; } = default!;
    public DateTime? SaleDate { get; set; }
    
    public int? CustomerId { get; set; }
    public Customer? Customer { get; set; }

    public int PaymentTypeId { get; set; }
    public PaymentType PaymentType { get; set; } = default!;

    public int CustomerTypeId { get; set; }
    public CustomerType CustomerType { get; set; } = default!;

    public ICollection<SaleItem> Items { get; set; } = default!;
}
