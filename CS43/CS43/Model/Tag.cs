using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS43.Model;

public class Tag
{
    // [Key] [StringLength(20)] public string TagId { set; get; }
    [Column(TypeName = "ntext")] public string Content { set; get; }
    
    [Key]
    public int TagId { set; get; }
}