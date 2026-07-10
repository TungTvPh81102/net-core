using System;

namespace CS24
{
    class CountNumber
    {
        public static int number = 0;

        public static void Info()
        {
            Console.WriteLine("So lan truy cap" + number);
        }

        public void Count()
        {
            // number++;
            CountNumber.number++;
        }
    }

    class Student
    {
        public readonly string name ; // Chỉ đọc dữ liệu

        public Student(string _name)
        {
            this.name = _name;
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            CountNumber.Info();

            Console.WriteLine(CountNumber.number);
            
            CountNumber c =  new CountNumber();
            CountNumber c2 = new CountNumber();

            c.Count();
            c2.Count();
            
            CountNumber.Info();
            
            Student st = new Student("Nguyen van a");
            // st.name = "nguyen van a";
            
            Console.WriteLine(st.name);
        }
    }
} 

// ReadOnly chỉ có thể đọc và k thể gán dữ liệu