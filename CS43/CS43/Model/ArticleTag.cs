using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS43.Model;

public class ArticleTag
{
    [Key]
    public int ArticleTagId { set; get; }
    
    public int TagId { set; get; }
    
    [ForeignKey("TagId")]
    public Tag Tag { set; get; }
    
    public int ArticleId { set; get; }
    
    [ForeignKey("ArticleId")]
    public Article Article { set; get; }
    
    
}