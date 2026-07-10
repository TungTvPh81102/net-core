using System;

namespace MyNamespace
{
    public  class Class1
    {
        public static void XinChao()
        {
            Console.WriteLine("Xin chào tu Class1");
        }
    }

    namespace Abc 
    {
        public class Class2
        {
            public static void XinChao()
            {
                Console.WriteLine("Xin chào tu Class2 trong namespace ABC");
            }
        }
    }
}