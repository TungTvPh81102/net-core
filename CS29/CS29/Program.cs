namespace CS29;

class Program
{
    static void DoSomThing(int seconds, string msg, ConsoleColor color)
    {
        lock (Console.Out)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"{msg,10} ... start");
        }

        for (int i = 1; i <= seconds; i++)
        {
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{msg,10} {i,2}");
                Console.ResetColor();
            }

            Thread.Sleep(1000);
        }

        Console.WriteLine($"{msg,10} ... End");
        Console.ResetColor();
    }

    static async Task Task2()
    {
        Task t2 = new Task(() => { DoSomThing(10, "T2", ConsoleColor.Green); });

        t2.Start();
        await t2;
        // t2.Wait();

        Console.Write("T2 da done");

        // return t2;
    }

    static async Task Task3()
    {
        Task t3 = new Task((object ob) =>
        {
            string tenTacVu = (string)ob;
            DoSomThing(4, tenTacVu, ConsoleColor.Yellow);
        }, "T3");

        t3.Start();

        await t3;

        // t3.Wait();

        Console.Write("T3 da done");

        // return t3;
    }

    static async Task Main(string[] args)
    {
        // DoSomThing(5, "ABC", ConsoleColor.Cyan);

        // asynchronous
        // Task, Task<T>

        // Task t2 = Task2();
        // Task t3 = Task3();

        // DoSomThing(10, "T2", ConsoleColor.Green);
        // DoSomThing(4, "T3", ConsoleColor.Yellow);

        // t2.Start();
        // t3.Start();
        // DoSomThing(6, "T1", ConsoleColor.White);

        // t2.Wait();
        // t3.Wait();
        // Task.WaitAll(t2, t3);

        // await t2;
        // await t3;

        Task<string> t4 = Task4();
        Task<string> t5 = Task5();

        // t4.Start();
        // t5.Start();

        Task.WaitAll(t4, t5);

        var kq4 = t4.Result;
        var kq5 = t5.Result;

        Console.WriteLine(kq4);
        Console.WriteLine(kq5);

        var task = GetWeb("https://www.youtube.com/");
        var content = await task;
        Console.WriteLine(content);

        // Console.WriteLine("press any key to exit");
        // Console.ReadKey();
    }

    static async Task Abc()
    {
        await File.WriteAllTextAsync("abc.txt", "abcd");
    }

    static async Task<String> Task4() // có giá trị trả về
    {
        Task<string> t4 = new Task<string>(() =>
        {
            DoSomThing(10, "T4", ConsoleColor.Green);
            return "Return form t4";
        });

        t4.Start();
        await t4;

        Console.Write("T4 da done");

        return t4.Result;
    }

    static async Task<string> Task5() // có giá trị trả về kiểu object
    {
        Task<string> t5 = new Task<string>((object ob) =>
        {
            string t = (string)ob;

            DoSomThing(4, "T5", ConsoleColor.Yellow);

            return $"Return form {t}";
        }, "T5");

        t5.Start();

        await t5;

        Console.Write("T5 da done");

        return t5.Result;
    }

    static async Task<string> GetWeb(string url)
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage kq = await client.GetAsync(url);

        string content = await kq.Content.ReadAsStringAsync();

        return content;
    }
}

// async, await
// Trong c# có phương thức Thread.Sleep(500)
// Console.Out thuộc tính hiển thị output trong console
// lock => khóa dữ liệu
// Task, Task<T> => sử dụng Start để khởi chạy Task
// Wait => đảm bảo task vụ phải hoàn thành thì mới đc phép thực hiên các bước tiếp theo => áp dụng cho 1 task
// Task.WaitAll => áp dụng truyền vào nhiều Task
// WriteAllTextAsync => bất đồng bộ tạo file
// Nếu muốn có giá trị trả về thì dùng Task<T> 
// Nhận kết quả thì khởi tạo biên = Task.Result()