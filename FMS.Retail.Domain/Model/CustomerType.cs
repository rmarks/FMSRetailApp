namespace FMS.Retail.Domain.Model;

public class CustomerType
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool HasCustomer { get; set; }
}
