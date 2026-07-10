// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int a;

Console.WriteLine("Nhap so nguyen a: ");
a = int.Parse(Console.ReadLine());

if (a%2 == 0)
{
    Console.WriteLine($"So {a} la so chan");
}else
{
    Console.WriteLine($"So {a} la so le");
}

Console.WriteLine("The End");