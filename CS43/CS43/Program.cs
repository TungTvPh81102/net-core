using CS43.Model;

namespace CS43;

class Program
{
    static void Main(string[] args)
    {
     
    }
}

// Migration và Scaffold 
// Tạo migration: dotnet ef migrations add MigrationName
//  dotnet ef migrations list => kiểm tra xem có những migration nào -> pending là chưa up lên DB
// dotnet ef migrations remove => xóa migration tạo cuối cùng
// dotnet ef database update => up migration lần lượt lên db
// dotnet ef database update [migationname] => chỉ chạy migration cụ thể hoặc rollback quay lại migration cũ
// dotnet ef database drop -f => toàn bộ db bị xóa
// dotnet ef migrations script => tạo tất cả migration thành 1 file script từ đầu tới cuối all file migrations
// dotnet ef migrations script Name1 Name => chuyển gộp migraion từ name 1 sang name 2
// dotnet ef migrations script -o migraions.sql => chuyển tất cả các migraions sang 1 file sql có tên migrations.sql

// Khi mà tạo chỉ mục k sử dụng kiểu attributes đc thì cần phải dùng Fluent Api

// Scaffold: đã có csdl từ đó có thể để tạo ra các model
// Data Source=localhost,1433;Initial Catalog=shopdata;Integrated Security=True;User ID=sa;Password=Password12;TrustServerCertificate=True;
// dotnet ef dbcontext scaffold -o Models -d "sqlCOnnectString" "Microsoft.EntityFrameWorkcore.SqlServer"
// dotnet ef dbcontext scaffold -o Modelsx -d "Data Source=localhost,1433;Initial Catalog=shopdata;Integrated Security=True;User ID=sa;Password=Password12;TrustServerCertificate=True" "Microsoft.EntityFrameWorkcore.SqlServer"