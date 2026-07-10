// See https://aka.ms/new-console-template for more information
namespace CS02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
            Khai báo biến sử dụng cú pháp như sau
            KieuDuLieu tenBien = giaTriKhoiTao;
            tenBien: 
            1. Tên từ a..z A..Z
            2. 0..9
            3. _
            4. Không bắt đầu bằng số
            5. Không trùng với từ khóa của C#
            */
            Console.WriteLine("Hello, World!");

            string studentName;
            int studentAge;

            char a;
            bool b; // true or false

            float c;

            double d = 3.14;

            double e;
            e = (float)12.3; // ép kiểu từ double sang float
            

            double soPi = 3.14;
            double haiPi = 2 * soPi;

            Console.BackgroundColor = ConsoleColor.Black; // Thiết lập màu bg
            Console.ForegroundColor = ConsoleColor.Red; // Thiết lập màu chữ

            Console.WriteLine(haiPi);

            Console.Title = "C# 02 - Khai báo biến"; // đặt tiêu đề cho cửa sổ console

            Console.ResetColor(); // Xóa màu

            Console.Write("Nhập tên của bạn: ");
            //Console.ReadKey(); // Sau khi hiển thị console.write thì nó sẽ dừng lại và cho phép người dùng nhập
            // Sau khi nhập console.readkey() xong thì chương trình vẫn chạy tiếp


            string nguoiYeu;
            nguoiYeu = Console.ReadLine(); // Nội dung của chữ được nhập vào
            // {0} nó giống kiểu gán chuỗi nó giống như `${}` trong JS
            Console.WriteLine("Người yêu của tôi tên là: {0}" , nguoiYeu);


            //float k, l;
            //string sinput;

            //Console.WriteLine("Nhap so a:");
            //sinput = Console.ReadLine();
            //a = float.Parse(sinput);

            //Console.WriteLine("Nhap so b:");
            //sinput = Console.ReadLine();
            //b = Convert.ToSingle(sinput);

            //Convert.WriteLine("So a = {0}, b = {1}", a, b);
        }
    }
}