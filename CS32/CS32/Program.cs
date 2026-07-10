using System.Reflection;

namespace CS32;

class Program
{
    static void Main(string[] args)
    {
        int a = 1;

        Type t1 = typeof(int);

        var t2 = typeof(string);

        var t3 = typeof(Array);

        var t = a.GetType();

        Console.WriteLine(t.FullName); // Gọi để kt kiểu type

        int[] b = { 1, 3, 3 };

        Type tb = b.GetType();

        Console.WriteLine(tb.FullName);

        Console.WriteLine("============ Cac thuoc tinh ============");
        tb.GetProperties().ToList().ForEach(o => { Console.WriteLine(o.Name); }); // lay ra cac thuộc tính

        Console.WriteLine("============ Cac truong du lieu ============");
        tb.GetFields().ToList().ForEach(o => { Console.WriteLine(o.Name); });

        Console.WriteLine("============ Get method ============");
        tb.GetMethods().ToList().ForEach(o => { Console.WriteLine(o.Name); });

        User user = new User()
        {
            Name = "TruongVanTung",
            Age = 20,
            Phone = "0088888811",
            Email = "tunny"
        };

        var properties = user.GetType().GetProperties();

        foreach (PropertyInfo items in properties)
        {
            string name = items.Name;
            var value = items.GetValue(user); // gọi getValue để lấy giá trị của thuộc tính của user
            Console.WriteLine($"{name} : {value}");
        }

        var P = user.GetType().GetProperties();

        foreach (PropertyInfo item in P)
        {
            foreach (var attr in item.GetCustomAttributes(false))
            {
                MotaAttribute mota = attr as MotaAttribute;

                if (mota != null)
                {
                    Console.WriteLine(mota.thongtinchitiet);
                    var values = item.GetValue(user);
                    var name = item.Name;
                    Console.WriteLine($"{name} {mota.thongtinchitiet}: {values}");
                }
            }
        }
    }

    [Mota("lop chua thong tin ve user tren he thong")]
    class User
    {
        [Mota("Ten nguoi dung")]
        public string Name { get; set; }
        
        [Mota("Age")]
        public int Age { get; set; }
        
        [Mota("Phone")]
        public string Phone { get; set; }
        
        [Mota("Email")]
        public string Email { get; set; }
        
        public void printinfo() => Console.WriteLine($"Name: {Name}, Age: {Age}, Phone: {Phone}");
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)] // nghĩa là khai báo để có thể áp dụng cho lớp, phương thức, method,... nào đó
    class MotaAttribute : Attribute
    {
        public string thongtinchitiet { get; set; }

        public MotaAttribute(string _thongtinchitiet)
        {
            this.thongtinchitiet = _thongtinchitiet;
        }
    }
}

// Attribute, Type, Reflection

// Type -> class, struct, ... int, bool
// Reflection: lấy thông tin kiểu dữ liệu, thời điểm tc thi

// Để xem kiểu dữ liệu thì goi tới getType() và truy cập tơis fullname
// System.Int32[] => vd day la kieu type la mảng
// GetProperties => lấy ra các thuộc tính cần duyệt qua mảng
// Getfields => trả về 1 mảng 
// Getmethod => trả về 1 mảng gồm các phần tử methodinfo

// attributename:  [AttributeName(thamso)]