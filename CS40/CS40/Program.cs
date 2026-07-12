using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CS40;

class Program
{
    static void CreateDb()
    {
        using var dbcontext = new ShopContext();

        string dbname = dbcontext.Database.GetDbConnection().Database; // lấy tên csdl

        var kq = dbcontext.Database.EnsureCreated();

        if (kq)
        {
            Console.WriteLine("The database has been created.");
        }
        else
        {
            Console.WriteLine("The database has been deleted.");
        }

        Console.WriteLine(dbname);
    }

    static void DropDb()
    {
        using var dbcontext = new ShopContext();

        string dbname = dbcontext.Database.GetDbConnection().Database; // lấy tên csdl

        var kq = dbcontext.Database.EnsureDeleted();

        if (kq)
        {
            Console.WriteLine("The database has been deleted.");
        }
        else
        {
            Console.WriteLine("Error cleared the database connection.");
        }

        Console.WriteLine(dbname);
    }

    static void InsertProduct()
    {
        using var dbcontext = new ShopContext();

        var products = new object[]
        {
            // new Product() { Name = "San pham 3", Provider = "Cong ty 3" },
            // new Product() { Name = "San pham 4", Provider = "Cong ty 4" },
            // new Product() { Name = "San pham 5", Provider = "Cong ty 5" },
        };

        // dbcontext.Add(p1); // them 1 du lieu
        dbcontext.AddRange(products); // them nhieu du lieu

        var kq = dbcontext.SaveChanges(); // cap nhat sql tra ve so dong dc tac dong trong db

        Console.WriteLine($"Da tren {kq} du lieu");
    }

    static void UpdateProduct(int id, string newName)
    {
        using var dbcontext = new ShopContext();

        Product product = (from p in dbcontext.products
            where p.ProductId == id
            select p).FirstOrDefault();

        if (product != null)
        {
            // product -> Dbcontext
            EntityEntry<Product> entry = dbcontext.Entry(product);
            entry.State = EntityState.Deleted; // nghĩa là sẽ tách product khỏi DbConntect nghĩa là sẽ k update nữa

            product.Name = newName;
            var kq = dbcontext.SaveChanges();
            Console.WriteLine($"Da cap nhat {kq} du lieu");
        }
    }

    static void DeleteProduct(int id)
    {
        using var dbcontext = new ShopContext();

        Product product = (from p in dbcontext.products
            where p.ProductId == id
            select p).FirstOrDefault();

        if (product != null)
        {
            dbcontext.products.Remove(product);
            var kq = dbcontext.SaveChanges();
            Console.WriteLine($"Da xoa nhat {kq} du lieu");
        }
    }

    static void ReadProducts()
    {
        using var dbcontext = new ShopContext();

        // Su dung Linq
        var products = dbcontext.products.ToList();

        var qr3 = from product in products
            where product.ProductId >= 3
            orderby product.ProductId descending
            select product;

        Product q4 = (from product in products
            where product.ProductId == 4
                  && product.Price >= 100
            select product).FirstOrDefault();

        products.ForEach(s => { s.PrintInfo(); });

        Console.WriteLine("San pham >=3");
        qr3.ToList().ForEach(x => x.PrintInfo());


        Console.WriteLine("San pham co id = 4");

        if (q4 != null)
        {
            q4.PrintInfo();
        }
    }

    static void InsertProduct2()
    {
        using var dbcontext = new ShopContext();

        // Category c1 = new Category()
        // {
        //     Name = "Dien Thoai",
        //     Description = "Câc loai dien thoai"
        // };
        //
        // Category c2 = new Category()
        // {
        //     Name = "Do uong",
        //     Description = "Câc loai do uong"
        // };
        //
        // dbcontext.categories.AddRange(c1, c2);

        var c1 = (from c in dbcontext.categories where c.CategoryId == 1 select c).FirstOrDefault();

        dbcontext.AddRange(
            new Product()
            {
                Name = "Iphone 14",
                Price = 100,
                CateId = c1.CategoryId
            },
            new Product()
            {
                Name = "Iphone 15",
                Price = 200,
                CateId = c1.CategoryId
            },
            new Product()
            {
                Name = "Iphone 16",
                Price = 300,
                CateId = c1.CategoryId
            },
            new Product()
            {
                Name = "Tra sua",
                Price = 100,
                CateId = 2
            },
            new Product()
            {
                Name = "Ruou",
                Price = 100,
                CateId = 2
            }
        );

        dbcontext.SaveChanges();
    }

    static void Main(string[] args)
    {
        // Entity => Database, Table
        // DB => DBContext
        // var dbContext = new UserDbContext(); // bieu dien 1 csdl

        DropDb();
        CreateDb();

        // InsertProduct();

        // ReadProducts();

        // UpdateProduct(1,"Dien Thoai");

        // DeleteProduct(3);

        // Logging

        // InsertProduct2();

        using var dbcontext = new ShopContext();

        var product = (from p in dbcontext.products where p.ProductId == 3 select p).FirstOrDefault();

        // var e = dbcontext.Entry(product); // lấy dữ liệu của Product tham chiếu tới model khác
        // e.Reference(p => p.Category).Load();
        
        // product.PrintInfo();

        // if (product.Category != null)
        // {
        //     Console.WriteLine($"{product.Category.Name} - {product.Category.Description}");;
        // }
        // else
        // {
        //     Console.WriteLine("Error cleared the product");
        // }
        
        var category = (from c in dbcontext.categories where c.CategoryId == 2 select c).FirstOrDefault();
        // var e2 = dbcontext.Entry(category);
        // e2.Collection(c => c.Products).Load(); // từ category lấy product
        //
        // Console.WriteLine(category.Name + category.CategoryId);

        // if (category.Products != null)
        // {
        //     Console.WriteLine($"So san pham la: {category.Products.Count()}");
        //     category.Products.ForEach(s => { s.PrintInfo(); });
        // }
        // else
        // {
        //     Console.WriteLine("Error cleared the category");
        // }
    }
}

// Entity Framework
// dbcontext.Database.GetDbConnection().Database => lay ten csdl
// dbcontext.Database.EnsureCreated() => kt nếu csdl chưa có thì sẽ tự động tạo => trả về true false
// && trong linq chính là and trong sql

//  EntityEntry<Product> entry = dbcontext.Entry(product); entry.State = EntityState.Deleted;  => tách khỏi theo dõi của DbCOnntect

// Table("tableNam")
// [key] => primary key
// [required] => not null
// [StringLength(50)] => nvarchar(50)
// [Column(TypeName = "ntext")] // => thiết lập kiểu dữ liệu trong db
// [Column("Tensanpham",TypeName = "ntext")] // => sẽ tương ứng khởi tạo cột trên db là tensanpham và type ntext
// [ForeignKey("CateId")] // nếu muốn tự đặt khóa thì sẽ thiết lập như này
// public int? CateId { get; set; } // đặt dấu ? nghĩa là có thể bằng null

// public List<Product> Products { get; set; } // Thể hiện mối quan hệ 1 nhiều
//  e2.Collection(c => c.Products).Load(); // từ category lấy product, lấy theo 1 nhiều
// Reference Navigation => Foreign Key (1-nhieu)
// Collect Navigation => k tạo ra fk
// Áp dụng lazy load dùng package dotnet add package Microsoft.EntityFrameworkCore.Proxies 
// -- Khi này khi lấy thông tin sản phấm nó cũng get category liên quan, ta cần thêm virtual vào trc pg t khởi tạo
// -- khi này sẽ k cần viết:  
// -- var e2 = dbcontext.Entry(category); và e2.Collection(c => c.Products).Load();

// InverseProperty => nhiều nhiều
// Khi có nhiều fk thì cần  [InverseProperty("Products")] => thiết lập xem phương thức kt của model sẽ lấy cái fk nào

// Fluent API 
// Có thể thiết lập các mối quan hệ bằng attribute hoặc fluent