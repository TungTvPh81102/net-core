namespace CS28;

class Program
{
    static void ListFileDirectory(string path)
    {
        String[] directories = System.IO.Directory.GetDirectories(path);
        String[] files = System.IO.Directory.GetFiles(path);
        foreach (var file in files)
        {
            Console.WriteLine(file);
        }

        foreach (var directory in directories)
        {
            Console.WriteLine(directory);
            ListFileDirectory(directory);
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("============= DriveInfo ==============");

        var drives = DriveInfo.GetDrives();

        DriveInfo drive = new DriveInfo(@"C:\");

        foreach (var items in drives)
        {
            Console.WriteLine($"Drive name: {drive.Name}");
            Console.WriteLine($"Drive type: {drive.DriveType}");
            Console.WriteLine($"Label: {drive.VolumeLabel}");
            Console.WriteLine($"Format: {drive.DriveFormat}");
            Console.WriteLine($"Size: {drive.TotalSize}"); // Tính theo byte
            Console.WriteLine($"Free: {drive.TotalFreeSpace}");
            Console.WriteLine("===========================");
        }

        Console.WriteLine("===========================");

        Console.WriteLine("============ Directory ===============");

        string path = "Abc";

        Directory.CreateDirectory(path); // Tạo thư mục
        Directory.Delete(path); // Xóa thư mục

        string path2 = "CS28";
        // var files = Directory.GetFiles(path2); // Lấy ra đường dẫn thư mục
        // var directories = Directory.GetDirectories(path2); // Danh sách thư mục con trong path2
        //
        // if (Directory.Exists(path))
        // {
        //     Console.WriteLine("Directory exists");
        // }
        // else
        // {
        //     Console.WriteLine("Directory does not exist");
        // }
        //
        // foreach (var file in files)
        // {
        //     Console.WriteLine($"File name: {file}");
        // }
        //
        // foreach (var VARIABLE in directories)
        // {
        //     Console.WriteLine($"File name: {VARIABLE}");
        // }
        Console.WriteLine(Environment.CurrentDirectory);
        string path3 = @"E:\senao\CS28\CS28";
        ListFileDirectory(path3);
        
        
        Console.WriteLine("============ FILE STREAM ===========");
        
        string filename = "abc.txt";
        string conten = "Xin chao cac ban";
        File.WriteAllText(filename, conten);  // Ghi file và tạo nội dung
        File.AppendAllText(filename, conten); // Ghi file và nội dung cũ vẫn còn và lưu thêm nội dung mới
    }
}

// ==================== Drive Info ====================
// Làm việc với thư mục và file, đọc ghi file với FileStream
// Sử dụng lớp DriveInfo
// IsReady => true ổ đĩa ở trạng thái hoạt đông và ngược lai
// DriveType => kiểu ổ đãi (System.IO.DriveType): CDRom, Fixed, Network, NoRootDirectory, Ram, Removable, Unknow
// VolumeLabel => nhãn đĩa
// DriveFormat => chuỗi cho biết định dạng đĩa: NTFS, FAT32, FAT, devfs
// AvailableFreeSpace => số byte có hiệu lực còn trốn
// TotalFreeSpace => số byte còn trống
// TotalSize => tổng số byte trên đĩa


// ==================== Directory - Thư mục ====================
// Exits(path) => kiêm tra xem thư mục có tồn tại k
// CreateDirectory => tạo thư mục trả về đối tượng System.IO.DriveInfo chứa thông tin thư mục
// Delete(path) => xóa thư mục
// GetFiles(path) => lấy các file trong thư mục
// GetDirectories(path) => lấy các thư mục trong thư mục
// Move(src,des) => di chuyển thư mục

// ==================== Path - hỗ trợ làm việc với đường dẫn ====================
// Combine => kết hợp với chuỗi thành đường dẫn => var path = Path.Combine("home", "ReadMe.txt"); //  "home/ReadMe.txt"
// ChangeExtension => thay đổi phần mở rộng của đường dẫn => var path = Path.ChangeExtension("/home/abc/ReadMe.txt", "md"); //  "/home/abc/ReadMe.md"
// GetDirectoryName => lấy đường dẫn đến thư muc => var path = Path.GetDirectoryName("/home/abc/zyz/ReadMe.txt"); //  "/home/abc/zyz"
// GetExtension => lấy phần mở rộng => var path = Path.GetExtension("/home/ReadMe.txt"); //  ".txt"
// GetFileName => lấy tên file => var path = Path.GetFileName("/home/abc/ReadMe.txt"); //  "ReadMe.txt"
// GetFileNameWithoutExtension => lấy tên file bỏ phần mở rông => var path = Path.GetFileNameWithoutExtension("/home/ReadMe.txt"); //  "ReadMe"
// GetFullPath => lây đường dẫn đầy đủ từ đường dẫn tương đối => var path = Path.GetFullPath("ReadMe.txt");
// GetPathRoot => lấy gốc của đường dẫn
// GetRandomFileName => tạo tên file ngẫu nhiên => var path = Path.GetRandomFileName();
// GetTempFileName => tạo file duy nhất, rỗng => var path = Path.GetTempFileName();