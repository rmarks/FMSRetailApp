using FluentValidation;

namespace FMS.Retail.Shared.Features.Sales;

public class SaleModel
{
    public int Id { get; set; }
    public string SaleNo { get; set; } = string.Empty;
    public DateTime? SaleDate { get; set; }
    public int CustomerTypeId { get; set; }
    public CustomerModel? Customer { get; set; }
    public int PaymentTypeId { get; set; }
    public List<SaleItemModel> Items { get; set; } = new List<SaleItemModel>();

    public void CopyFrom(SaleModel source)
    {
        this.Id = source.Id;
        this.SaleNo = source.SaleNo;
        this.SaleDate = source.SaleDate;
        this.CustomerTypeId = source.CustomerTypeId;
        this.Customer = source.Customer;
        this.PaymentTypeId = source.PaymentTypeId;
        this.Items = source.Items.Select(i => new SaleItemModel
        {
            Id = i.Id,
            SaleId = i.SaleId,
            ProductId = i.ProductId,
            ProductCode = i.ProductCode,
            ProductName = i.ProductName,
            ProductPrice = i.ProductPrice,
            Quantity = i.Quantity
        }).ToList();
    }
}

public class SaleItemModel
{
    public int Id { get; set; }
    public int SaleId { get; set; }

    public int ProductId { get; set; }
    public string ProductCode { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public decimal ProductPrice { get; set; }

    public int Quantity { get; set; }

    public SaleItemModel GetCopy()
    {
        return new SaleItemModel
        {
            Id = Id,
            SaleId = SaleId,
            ProductId = ProductId,
            ProductCode = ProductCode,
            ProductName = ProductName,
            ProductPrice = ProductPrice,
            Quantity = Quantity,
        };
    }

    public void CopyFrom(SaleItemModel source)
    {
        Id = source.Id;
        SaleId = source.SaleId;
        ProductId = source.ProductId;
        ProductCode = source.ProductCode;
        ProductName = source.ProductName;
        ProductPrice = source.ProductPrice;
        Quantity = source.Quantity;
    }
}

public class SaleModelValidator : AbstractValidator<SaleModel>
{
    public SaleModelValidator()
    {
        RuleFor(s => s.CustomerTypeId).NotEmpty().WithMessage("Sisesta kliendi tüüp");
        RuleFor(s => s.PaymentTypeId).NotEmpty().WithMessage("Sisesta maksetüüp");
        //RuleFor(s => s.Customer).NotNull().When(s => string.IsNullOrWhiteSpace(s.Customer?.Name)).WithMessage("Sisesta kliendi nimi");
    }
}
