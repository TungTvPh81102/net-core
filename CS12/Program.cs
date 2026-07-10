// Struct

class Programs
{
    public static void Main(string[] args)
    {
        Product sanPham1;

        sanPham1.name = "Iphone 14 Pro Max";
        sanPham1.price = 1000;

        Console.WriteLine(sanPham1.getInfo());

        Product sanPham2 = new Product("Nokia", 9000);

        Console.WriteLine(sanPham2.getInfo());

        Console.WriteLine(sanPham2.info);

        sanPham2 = sanPham1; // Khi gán ntn thì dữ liệu của sp1 được gán vào sp2

    }

    // Để khai báo 1 struct, sử dụng từ khóa struct
    // Nó giống lới class nên cũng có phạm vi truy cập, có thể có các phương thức, thuộc tính, và các thành phần khác

    public  struct Product
    {
        // Trong đây định nghĩa kiểu dữ liệu
        // Dữ liệu, phương thức, constructor, thuộc tính, indexer, sự kiện, và các thành phần khác
        // Struct là kiểu tham trị

       public string name;

        public double price;

        public string info
        {
            get
            {
                return $"{name},{price}";
            }
        }

        public string getInfo()
        {
            return $"Tên sản phẩm: {name}, giá: {price}";
        }

        //constructor

        public Product(string _name, double _price)
        {
            this.name = _name;
            this.price = _price;
        }

    }
}