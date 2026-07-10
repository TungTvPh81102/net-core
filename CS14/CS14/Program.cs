using System;
using MyNamespace; // Nạp namespace vào mã mã nguồn
using MyNamespace.Abc;


namespace CS14
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cat c = new Cat();
            //
            // c.ShowLegs();
            // c.Eat();
            //
            // c.ShowInfo();
            
            // Hiển thị của Namespace
            // MyNamespace.Class1.XinChao();
            // MyNamespace.Abc.Class2.XinChao();
            
            SanPham.Product product = new SanPham.Product();
            product.name = "Ipad";
            product.price = 1000;
            
            Console.WriteLine(product.name);
            Console.WriteLine(product.price);
        }
    }

    class Animal
    {
        public Animal()
        {
            Console.WriteLine("Animal constructor 1"); // Khởi tạo
        }

        public Animal(string name)
        {
            Console.WriteLine("Khởi tạo Animal 2");
        }
        
        public int Leg { set; get; }

        public float Weight { set; get; }

        public void ShowLegs()
        {
            Console.WriteLine($"Legs: {Leg}");
        }

        private void Animation()
        {
            Console.WriteLine("Animation");
        }

        protected void HideLegs()
        {
            Console.WriteLine("HideLegs");
        }
    }

    class Cat : Animal // Trong C# thì đây là biểu diễn cho kế thừa
    {
        public string Food;

        public Cat() : base("Gọi phương thức số 2") // Ở đây nếu tham số có chuỗi nó sẽ gọi phương thức khởi tạo số 2 của lớp cha
        {
            this.Leg = 4;
            this.Food = "Mouse";
            this.HideLegs();    
            Console.WriteLine("Cat constructor"); // Khởi tạo
        }

        public void Eat()
        {
            Console.WriteLine(Food);
        }

        public new void ShowLegs() // Phương thức này sẽ ghi đè của lớp cha
        {
            Console.WriteLine($"Loài mèo có {Leg} chân");
        }

        public void ShowInfo()
        {
            ShowLegs(); // Lúc này sẽ gọi phương thức mới ở lớp kế thừa -- Lớp kế thừa ghi đè
            base.ShowLegs(); // Để sử dụng phương thức của lớp cha thì dùng từ khóa base -- Của lớp cha
        }
    }
    
    /*
     * Trong OOP:
     * Khi đặt từ khóa sealed trước class thì nó sẽ không cho phép hay còn gọi là bị iêm phong kế thừa: sealed tênclass
     * Đề ghi đè phương thức từ lớp class cha ta sẽ khai báo: public new void tên phương thức ghi đè()
     * Từ khóa base sẽ cho phép truy cập lại thuộc tính phương thức của lơp cha
     * Trong kế thừa thì phương thức của lớp khởi tạo luôn thi hành trước
     */
}