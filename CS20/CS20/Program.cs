using System;

namespace CS20
{
    public delegate void ShowLog(string msg);


    class Program
    {
        static void Info(string s)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        static void Warning(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        delegate int kieu1();

        static int Tong(int a, int b) => a + b;
        static int Hieu(int a, int b) => a - b;
        

        public static void Main(string[] args)
        {
            ShowLog log = null;

            log = Info;

            if (log != null)
            {
                // 2 cách gọi log đều tương đương nhau            
                log("Xin chào");
            }

            log?.Invoke("Xin chào 2");

            log = Warning;

            log("Học về delegate");

            log += Info;
            log += Warning;

            log("Tham chieu ca 2");

            // Action, Func: delegate - gereric
            // Action k cần kiểu trả về
            Action action; // giống khai báo delegate void kieu();
            Action<string, int> action1; // ~ delegate void kieu(string s,int i)

            Action<string> action2; // ~ delegate void kieu(string s)

            action2 = Warning;
            action2 += Info;

            action2?.Invoke("Thong bao tu action 2");

            //  Sử dụng Func cần có kiểu trả về
            Func<int> f1; // lúc này cần trả về kiểu int ~ delegate int kieu()
            Func<string, double, string> f2; // ~ delegate string kieu(string, double); -> string ở cuối là func sẽ trả về string

            Func<int, int, int> tinhToan; // ~ delegate int Kieu(int a, int b) -> trả về int
            int a = 5;
            int b = 10;
             
            tinhToan = Tong;
            Console.WriteLine($"Tong la {tinhToan(a, b)}");
        }
    }
}

// Sử dụng delegate, khai báo delegate Action, delegate Func 
// Khởi tạo delegate: delegate (Type) bien = phuongthuc
// Action, Func: delegate - gereric