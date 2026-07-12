using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS40;

[Table("products")] // khởi tạo để model nhận table products trong db
public class Product
{
    [Key] // <=> primarykey
    public int ProductId { get; set; }

    [Required] // <=> not null
    [StringLength(50)] // mặc định cái này sẽ tạo luôn trong db <=> nvarchar 50
    // [Column(TypeName = "ntext")] // => thiết lập kiểu dữ liệu trong db
    [Column("Tensanpham", TypeName = "ntext")] // => nếu trong db và trong model cột khác nhau thì
    // sẽ tương ứng khởi tạo cột trên db là tensanpham và type ntext
    public string Name { get; set; } = string.Empty;

    [Column(TypeName = "money")] public decimal Price { get; set; }

    public int? CateId { get; set; } // đặt dấu ? nghĩa là có thể bằng null

    // Các tạo fk
    // mặc định convention sẽ tự động tạo khóa chính là CategoryId tuy nhiên nếu không muốn tự tạo CategoryId mà tự đặt khó thì
    [ForeignKey("CateId")] // nếu muốn tự đặt khóa thì sẽ thiết lập như này
    [Required]
    public virtual Category Category { get; set; } // sẽ tạo mối liên hệ và tạo ra fk

    // public int? CateId2 { get; set; }
    //
    // [ForeignKey("CateId2")]
    // [InverseProperty("Products")] // thiết lập xem nó sẽ lấy khóa fk nào
    // [Required]
    // public virtual Category Category2 { get; set; }

    public int UserId { get; set; }
    
    public DateTime DateCreated { get; set; }
    
    
    public void PrintInfo()
    {
        Console.WriteLine($"ProductId: {ProductId} - Name: {Name} - Price: {Price} - CateId: {CateId}");
        ;
    }
}