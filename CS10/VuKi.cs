using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CS10
{
    public class VuKi
    {
        // Trường dữ liệu trong lớp
       public string name = "Tên vũ khí"; // nếu k khai báo phạm vi truy cập thì mặc định là private

        int dosatthuong = 0;

        // Thuộc tính set là =, thuộc tính get là truy cập
        // Để lấy giá trị từ thuộc tính set được truyền và gán vào thì ta dùng value
        // Trong thuộc tính có thể có get hoặc set hoặc có thể có cả 2
        public int satThuong
        {
            set
            {
                dosatthuong = value;
            }

            get
            {
                return dosatthuong;
            }
        }

        public string noisx { set; get; } // thuộc tính gán tự động


        // Phương thức khởi tạo
        public VuKi() { 
            Console.WriteLine("VuKi class instantiated.");
            dosatthuong = 5;
        }
     
        public void thietLapSatThuong (int dosatthuong)
        {
            this.dosatthuong = dosatthuong; // Sử dụng từ khóa this để tham chiếu đến trường dữ liệu của lớp
        }

        public void tanCong()
        {
            Console.WriteLine(name + ": \t");
            for (int i = 0; i < this.dosatthuong; i++)
            {
                Console.WriteLine(" * ");
            }
            Console.WriteLine();
        }

        public VuKi (string name, int _dosatthuong)
        {
            dosatthuong = _dosatthuong;
            this.name = name;
        }
    }
}
