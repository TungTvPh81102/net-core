// Cấu trúc dữ liệu mảng 

// Console.ReadKey() -> lấy 1 giá trị nhập từ bàn phím và trả về giá trị đó thông qua KeyChar
// Console.ReadLine() -> lấy 1 chuỗi nhập từ bàn phím và trả về chuỗi đó

string[] danhSachSinhVien;

danhSachSinhVien = new string[3];

danhSachSinhVien[0] = "Nguyen Van A";
danhSachSinhVien[1] = "Nguyen Van B";
danhSachSinhVien[2] = "Nguyen Van C";

for (int i = 0; i <= 2; i++)
{
    Console.WriteLine(danhSachSinhVien[i]);
}
// Khởi tạo mảng
// string[] mang1 = new string[2] {"Laptop","Dien Thoai"}; hoặc string[] mang1 = {"Laptop","Dien Thoai"};

int[] mangSoNguyen;
string[] mang1 = new string[2] {"Laptop","Dien Thoai"};
double[] mang2 = new double[2];

mangSoNguyen=  new int[3] {1,2,0};

//Console.WriteLine(mang1);

int[] numbers = { 1, 4, 7, 4, 3, 7, 34, 7 };

//for (int i = 0; i <= numbers.Length; i++)
//{
//    Console.WriteLine(numbers[i]);
//}

foreach (var item in numbers)
{
    Console.WriteLine(item);
}

//Console.WriteLine($"Min",numbers.Min());
//Console.WriteLine($"Max",numbers.Max());
//Console.WriteLine($"Sum", numbers.Sum());

// Sắp xếp mảng 1 chiều tăng dần
Array.Sort(numbers);

foreach (var item in args)
{
    Console.WriteLine(numbers);
}
