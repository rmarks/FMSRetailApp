namespace FMS.Retail.Shared.Features.Sales;

public class CustomerTypeModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool HasCustomer { get; set; }
}
