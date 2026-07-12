using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CS40
{
    public class ShopContext : DbContext
    {
        public static readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
            builder.AddFilter(DbLoggerCategory.Database.Name, LogLevel.Information);
            builder.AddConsole();
        });

        // public DbSet<User> Users { set; get; } // biểu diễn tương đương với 1 bảng users
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }

        private const string connectString =
            "Data Source=localhost,1433;Initial Catalog=shopdata;Integrated Security=True;User ID=sa;Password=Password12;TrustServerCertificate=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(_loggerFactory);
            optionsBuilder.UseSqlServer(connectString);
            optionsBuilder.UseLazyLoadingProxies();

            Console.WriteLine("OnConfiguring");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Gọi fluent Api ở đây
            // var entity =  modelBuilder.Entity(typeof(Product)); --> cách 1
            // sử dụng entity để => fluent api - product

            // var entity = modelBuilder.Entity<Product>(); // -> cách 2

            modelBuilder.Entity<Product>(e =>
            {
                // table mapping
                e.ToTable("products"); // tương ứng với bảng trên Db khi sử dụng có thể bỏ Table("Products") trong model

                // Pk
                e.HasKey(x => x.ProductId); // ở đây chỉ ra ProductId chính là khóa chính

                // index
                e.HasIndex(x => x.Price); // đánh index cho price

                // hasdatabasename("index-product-price) -> đặt tên cho chỉ mục chứ k lấy tên tạo mặc định

                // Thiết lập mối liên hệ - relative
                e.HasOne(x => x.Category).WithMany().HasForeignKey("CateId").OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("khoa_ngoai_product_category"); // 1 - nhiều

                // HasForeignKey đặt tên cho foreignkey = HasForeignKey
                // OnDelete(DeleteBehavior.Cascade) -> thiết lập thêm mối quan hệ
                // HasConstraintName đặt tên constaintname của fk nếu k set thì sẽ tự động tạo tên

                e.HasOne(x => x.Category).WithMany().HasForeignKey("CateId2").OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("khoa_ngoai_product_category_2");

                e.Property(p => p.Name)
                    .HasColumnName("name") // thiết lập tên cột
                    .HasColumnType("nvarchar") // thiết lập kiểu dữ liệu
                    .HasMaxLength(50) // thiết lập độ dài
                    .IsRequired(true) // thiết lập not null, nếu là false thì là null
                    .HasDefaultValue("no data") // đặt giá trị mặc định
                    ;
            }); // -> cách 3
        }
    }
}

// DB COntext này giống như 1 nơi đăng ký các model con 