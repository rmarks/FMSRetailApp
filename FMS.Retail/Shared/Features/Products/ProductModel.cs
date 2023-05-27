using FluentValidation;

namespace FMS.Retail.Shared.Features.Products;

public class ProductModel
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}

public class ProductModelValidator : AbstractValidator<ProductModel>
{
    public ProductModelValidator()
    {
        RuleFor(p => p.Code).NotEmpty().WithMessage("Sisesta kood");
        RuleFor(p => p.Name).NotEmpty().WithMessage("Sisesta nimi");
        RuleFor(p => p.Price).NotEmpty().WithMessage("Sisesta hind");
    }
}
