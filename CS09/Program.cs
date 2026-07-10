
// Phương thức trong C#

// Cần xác định xem phương thức có trả về hay không, để có thể tạo phương thức phù hợp
// Phương thức tĩnh chỉ cần gọi mà không cần tạo đối tượng thì thêm static vào trước (nghĩa là k cần tạo new đối tượng)
// Void : là phương thức không trả về giá trị

// Nếu phương thức là static thì sẽ truy cập thông qua namespace.xinchao() mà không cần tạo đối tượng


//static void xinChao()
//{
//    Console.WriteLine("Xin chao cac ban");
//}

//xinChao();

// Cú pháp khai báo phương thức
// Cần khai báo trong 1 lớp
// Phạm vi truy cập: public, private, protected
// Nếu k trả về giá trị khai báo void
// Còn trả về giá trị thì cần khai báo giá trị trả về

class Program
{
    public static void Main(string[] args)
    {
      var result =   CS09.TinhToan.tinhTong(1,2);
        Console.WriteLine(result);

        xinChao("Tung","Truong Van");
    }

    // Như đây chính là phương thức trả về giá trị
    //public static int tich(int a, int b)
    //{
    //    int result;

    //    result = a * b;
    //    return result;
    //}

    static void xinChao (string ten, string ho)
    {
        string fullname;

        fullname = ho + " " + ten;

        Console.WriteLine(fullname);
    }
}
