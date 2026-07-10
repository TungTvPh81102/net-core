using System;

namespace CS21
{
    class Program
    {
        public static void Main(string[] args)
        {
            Action<string> thongbao;
            thongbao = (string s) => Console.WriteLine(s); // ~ delegate void kieu(string s) = Action <string>
            
            thongbao?.Invoke("Xin chao");

            Action thongbao2;
            thongbao2 = () => Console.WriteLine("Xin chao cac ban");
            thongbao2?.Invoke();

            Action<string> wellcome;
            wellcome = (s) => Console.WriteLine("Welcome " + s);
            wellcome?.Invoke("Xin chao");
            
            Action<string,string> wellcome2;
            wellcome2 = (string msg, string name) => Console.WriteLine("Welcome " + msg + name);
            wellcome2.Invoke("Xin chao","name");
            
            
            // (int a, int b) =>
            // {
            //     int kq = a + b;
            //     return kq;
            // }
        }
    }
}

// Biểu thức lambda, viết và sử dụng biểu thức lambda với delegate 