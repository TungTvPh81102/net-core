using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CS43.Modelsx;

[Table("categories")]
public partial class Category
{
    [Key]
    public int CategoryId { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Column("description", TypeName = "ntext")]
    public string Description { get; set; } = null!;

    [InverseProperty("Cate")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
