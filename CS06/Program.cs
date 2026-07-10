int a;
a = 3;

if (a == 1)
{
    Console.WriteLine("Gia tri a bang 1");
}else if (a == 2)
{
    Console.WriteLine("Gia tri a bang 2");
}else
{
    Console.WriteLine("Hay kiem tra so khac");
}

int b = 811;

switch (b)
{
    case 1:
        Console.WriteLine("Gia tri b bang 1");
        break;
    case 2:
        Console.WriteLine("Gia tri b bang 2");
        break;
    default:
        Console.WriteLine($"Gia tri b bang {b}");
        break;
}

int c, d;

Console.WriteLine("Nhap so c");
c = int.Parse(Console.ReadLine());

Console.WriteLine("Nhap so d");
d = int.Parse(Console.ReadLine());

Console.WriteLine("Hay chon lenh can thuc hien:");
Console.WriteLine("1. Tinh tong");
Console.WriteLine("2. Tinh hieu");
Console.WriteLine("3. Tinh tich");
Console.WriteLine("4. Tinh thuong");

char f;
L1:
f = Console.ReadKey().KeyChar; // ReadKey là khi ấn 1 ký tự trên bàn phím, KeyChar nhận được giá trị trên bàn phím và lưu lại
// Ví dụ nhấn readkey là 1 thì lúc này keychar sẽ tra về giá trị = 1

switch (f)
{
    case '1':
        Console.WriteLine($"Tong la: {c + d}");
        break;
    case '2':
        Console.WriteLine($"Hieu la: {c -d}");
        break;
    case '3':
        Console.WriteLine($"Tich la: {c * d}");
        break;
    case '4':
        Console.WriteLine($"Thuong la: {c / d}");
        break;
    default:
        Console.WriteLine("Thoat khoi chuong trinh");
        // Nếu đặt goto thì nó sẽ quay lại điểm được bắt đầu, tên thì đặt bất kì nha
        // Khi đăt goto tenBien thì lúc này chương trình sẽ không bị thoát nữa mà nó sẽ cho phép ta tiếp tục nhập
        goto L1; 
        break;
}
