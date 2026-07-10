using System;

namespace CS23
{
    // Đây là 1 phuong thức tĩnh
    static class Abc
    {
        public static void Print(this string s, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(s);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            int[] mang = { 1, 2, 4, 6, 3 };
            int max = mang.Max();

            var search = mang.Where(x => x <= 6);

            foreach (var items in search)
            {
                Console.WriteLine(items);
            }
            
            Console.WriteLine(max);

            string s = "Xin chao cac ban";
            
            s.Print(ConsoleColor.Yellow);
            s.Print(ConsoleColor.Green);
            s.Print(ConsoleColor.Red);
        }
    }
}

// Extension method

