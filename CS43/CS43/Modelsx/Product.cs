using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CS43.Modelsx;

[Table("products")]
[Index("CateId", Name = "IX_products_CateId")]
public partial class Product
{
    [Key]
    public int ProductId { get; set; }

    [Column(TypeName = "ntext")]
    public string Tensanpham { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal Price { get; set; }

    public int CateId { get; set; }

    [ForeignKey("CateId")]
    [InverseProperty("Products")]
    public virtual Category Cate { get; set; } = null!;
}
