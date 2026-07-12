using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS40;

[Table("categories")]
public class Category
{
    [Key] public int CategoryId { get; set; }

    [Required] [StringLength(50)] public string Name { get; set; }

    [Column("description", TypeName = "ntext")]
    public string Description { get; set; }
    
    public virtual List<Product> Products { get; set; } // Thể hiện mối quan hệ 1 nhiều
}