namespace CS19;

class Program
{
    // Interface
    interface IHinhHoc
    {
        public double tinhChuVi();

        public double tinhDienTich();
    }

    class HinhChuNhat : IHinhHoc
    {
        public double a { set; get; }

        public double b { set; get; }

        public double tinhChuVi()
        {
            return 2 * (a + b);
        }

        public double tinhDienTich()
        {
            return a * b;
        }

        public HinhChuNhat(double _a, double _b)
        {
            a = _a;
            b = _b;
        }
    }

    // Virual method thì khai báo đầu class bằng từ virtual

    abstract class Product
    {
        protected double price { set; get; }

        // public virtual void ProductInfo() // Khi thêm virtual thì lúc này ProductInfo là pt ảo và có thể định nghĩa lại 
        // {
        //     Console.WriteLine("Product Info " + price);
        // }

        public abstract void ProductInfo();

        public void Test()
        {
            ProductInfo();
        }
    }

    class Iphone : Product
    {
        public Iphone() => price = 500;

        void Abc() => Console.WriteLine("Abc");

        int tong(int a, int b) => a + b;

        // Override - nạp chồng phương thức 
        // public override void ProductInfo()
        // {
        //     Console.WriteLine("Dien thoai IP " + price);
        //     base.ProductInfo();
        // }

        public override void ProductInfo()
        {
            Console.WriteLine("Dien thoai IP " + price);
            Console.WriteLine("Gia san pham" + price);
        }
    }

    public static void Main(string[] args)
    {
        // Product p = new Iphone();

        Iphone i = new Iphone();
        i.Test();


        HinhChuNhat a = new HinhChuNhat(4, 6);
        
        Console.WriteLine(a.tinhChuVi());
        Console.WriteLine(a.tinhDienTich());
    }
}

// Khi thêm từ khóa virtual thì xác định đây là 1 phương thức ảo
// Khi muốn ghi đè phương thức thì dùng override
// abstract là 1 lớp trừu tượng nên k được phép tạo ra các đối tượng và chỉ đc làm cơ s cho ớp kế thừa