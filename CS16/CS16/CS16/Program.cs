using System;
using Nullandnullable;

class Program
{
    static void Swap(ref int x, ref int y)
    {
        int temp = x;
        temp = x;
        x = y;
        y = temp;
    }

    class SinhVien
    {
        public string name { set; get; }

        public int year { set; get; }

        public string live { set; get; }
    }

    public static void Main()
    {
        int a = 5;
        int b = 6;

        Console.WriteLine(a);
        Console.WriteLine(b);
        Swap(ref a, ref b);
        Console.WriteLine(a);
        Console.WriteLine(b);

        List<SinhVien> ds = new List<SinhVien>()
        {
            new SinhVien() { name = "Nguyen Van A", year = 10, live = "Ha Nam" },
            new SinhVien() { name = "Nguyen Van B", year = 1, live = "Ninh Binh" },
            new SinhVien() { name = "Nguyen Van C", year = 12, live = "Ha Nam" }
        };

        // Sử dụng LINQ
        var ketqua = from sinhVien in ds
                where sinhVien.year <= 10
                select new
                {
                    ten = sinhVien.name,
                    ns = sinhVien.year
                }
            ;

        // sinhVien.name.Contains("a") - kiểm tra xem trong name có chữ a hay không

        foreach (var items in ketqua)
        {
            Console.WriteLine(items.ten + " " + items.ns);
        }

        // Dynamic
        dynamic tenBien1;
        var tenBien2 = 123; // Khi khai báo var bắt buộc phải gán giá trị

        int abv = 1;
        Student abc = new Student();
        PrintInfo(abc);


        Console.WriteLine("============= Null and Nullable =============");

        Nullandnullable.Abc xx = new Abc();
         xx = null;
        // if (a != null)
        // {
        //     xx.Xinchao();
        // }
        
        
        // Có thể viết ngăn gọn để kiểm tra
        // a != null <=> a?.XinChao(); nghĩa là thay != thành ?.
        xx?.Xinchao();  
        
        Console.WriteLine("============= Null and Nullable =============");

        int? age;
        age = null;

        age = 10;

        if (age.HasValue)
        {
            int _age = age.Value;
            Console.WriteLine(_age);
        }
    }

    class Student
    {
        public void Hello() => Console.WriteLine("Hello");
        public string Name { set; get; }
    }

    static void PrintInfo(dynamic obj)
    {
        obj.Name = "Nguyen Van A";
        obj.Hello();
    }
}

// Tìm hiểu về phương thức generic
// List<int> list1 = new List<int>();
// List<string> list2 = new List<string>();

// HasValue -> Kiểm tra có giá trị hay không => kiểm tra bằng cách .value
// a != null <=> a?.XinChao(); nghĩa là thay != thành ?.

// Ép kiểu float => int bằng cách (int) giá trị