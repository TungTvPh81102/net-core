using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS10
{
     class Program
    {
   static void Main(string[] args)
        {
            VuKi sungLuc;
            sungLuc = new VuKi();
            Console.WriteLine(sungLuc.name);
            sungLuc.thietLapSatThuong(5);

            Console.WriteLine(sungLuc.satThuong);
            

            VuKi sungMay = new VuKi("Sung may", 15);

            sungLuc.tanCong();
            sungMay.tanCong();

            sungLuc.noisx = "Viet Nam";

            Console.WriteLine(sungLuc.noisx);

            Student student;
            student = new Student("Sinh vien 1");
            student = null;

            using (Student s = new Student ("Ten Sinh vien")
            {
                // ... s
            }
        }
    }


    // Để tạo phương thức hủy thì sẽ bắt đầu bằng ~ và k có tham số và giá trị trả về
    // Dùng IDisposable cho phương thức hủy cần tạo thêm Dispose để xử lý
    // Khi này sẽ sử dụng using để xử lý, nó chỉ được phép truy cập trong using, khi ra khỏi phạm vi thì sẽ được giải phòng

    class Student : IDisposable
    {
        public string name;
        public Student (string name)
        {
            this.name = name;
        }

        ~Student ()
        {
            Console.WriteLine("Huy" + name);
        }
        public void Dispose()
        {
            Console.ResetColor();
        }
    }

}
