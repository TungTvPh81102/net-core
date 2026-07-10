// Học về vòng lpawj for, while, break, continue
// For và While thì sẽ kiểm tra điều kiện trước sau đó mới chạy lệnh, do-while sẽ kiểm tra lệnh trước và điều kiện sau

/*
 for (khởi tạo; điều kiện; bước nhảy)
 {
     // khối lệnh
 }
 Cần chú ý điều kiện để tránh vòng lặp vô tận
 */

for (int i = 1; i <= 10; i++)
{
    Console.WriteLine($"Cac gia tri cua {i}");
    Console.WriteLine("Anh yeu em");
}

// Bảng cửu chương của 9 
for (int i = 1; i <= 10; i++)
{
    Console.WriteLine($"8 x {i} = {8*i}");
}

// Vòng lặp while, khi k cần khởi tạo điều kiện thì nên dùng lệnh này

int x = 1;
while (x<=10)
{
    Console.WriteLine($"8 x {x} = {8 * x}");
    x++;
}

// Vòng lặp do-while, khối lệnh bên trong thực hiện trước sau đó mới kiểm tra điều kiện

do
{
    Console.WriteLine($"8 x {x} = {8 * x}");
    x++;
}
while (x <= 10);

// Break và continue

int t = 0;
while (t < 10)
{
    Console.WriteLine(t);
    t++;
    if (t == 4)
        break;
}


for (int z = 10; z <= 20; z++)
{
    if (z %2 != 0) // Sẽ k in ra số i khi gặp điều kiện này
    {
         continue;
    }
    Console.WriteLine($"So z = {z}");
}