using System;

namespace CS22
{
    public delegate void SuKienNhapSo(int x);
        
    class Program
    {
        public static void Main(string[] args)
        {
            UserInput userInput = new UserInput();
            // userInput.Input();

            TinhCan can = new TinhCan();
            can.Sub(userInput);
        }
    }

    // publisher
    class UserInput
    {
        public SuKienNhapSo suKienNhapSo {set;get;}
        
        public void Input()
        {
            do
            {
                Console.WriteLine("Nhap vao so nguyen");
                string s = Console.ReadLine();
                int i = Int32.Parse(s);
            
                suKienNhapSo?.Invoke(i);
            } while (true);
        }
    }

    class TinhCan
    {
        public void Sub(UserInput input)
        {
            input.suKienNhapSo = Can;
        }
        
        public void Can(int i)
        {
            Console.WriteLine($"Can bac 2 cua so {i} la {Math.Sqrt(i)}");
        }
    }
}

// Event và EventHandler 
/*
 * publisher -> class -> phat sự kiện
 * subsriber -> class -> nhận sự kiện
 */