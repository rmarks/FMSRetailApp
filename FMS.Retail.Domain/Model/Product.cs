using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Retail.Domain.Model;

public class Product
{
    public int Id { get; set; }

    [MaxLength(10)]
    public string Code { get; set; } = default!;

    [MaxLength(50)]
    public string Name { get; set; } = default!;

    [Column(TypeName = "decimal(9, 2)")]
    public decimal Price { get; set; }
}
