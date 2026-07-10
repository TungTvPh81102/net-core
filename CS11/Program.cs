// Chuỗi ký tự string và lớp StringBuilder

using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string loiChao; // k khởi tạo thì là null
        string ten = "NguyenVanA";
       loiChao =  "Xin chao";

        string thongBao = loiChao + " " + ten;
        thongBao += "!"; // nối thêm vào chuỗi bằng toán tử +=

        Console.WriteLine(thongBao);


        string thongbao2;
        thongbao2 = "Hoc ve chuoi ky tu string \"String\""; // Để chèn thêm 1 chuỗi vào thì cần sử dụng dấu \"

        // \t -> chèn tab
        // \n -> xuống dòng
        // \r -> trở về đầu dòng

        Console.WriteLine(thongbao2);


        string thongbao3;
        thongbao3 = @"Xin chao 2021        Hoc haha";
        Console.WriteLine(thongbao3);
        // @: chuỗi nguyên gốc, không cần escape ký tự đặc biệt


        string thongbao4 = "NguyenVanB, xin cho cac ban! ";

        int dodai = thongbao4.Length;

        Console.WriteLine(dodai);

        thongbao4 = thongbao4.Trim();
        // Nếu muốn cắt kí tự cụ thể thì cần điền kí tự đó vào Trim();
        // trimStart() -> cắt ký tự ở đầu
        // trimEnd() -> cắt ký tự ở cuối
        // replace(xinchao,chaomung) -> sẽ tìm trong chuỗi có xinchao thì sẽ đổi thành chao mung
        // insert(vịtri,giá trị cần chèn) 
        // subString(startindex,endindex) -> lấy ra chuỗi con khi điền giá trị
        // remove() -> loại bỏ các ký tự có chỉ sô tương ứng
        // split(' ') 
        // join() 

        Console.WriteLine(thongbao4);

        string[] cacchuoicon = thongbao4.Split(' ');

        foreach (var item in thongbao4)
        {
            Console.WriteLine(item);
        }

        // Lớp StringBuilder

        StringBuilder thongBao5 = new StringBuilder();

        thongBao5.Append("Xin");// Cái này giống join
        thongBao5.Append(" Chao"); // Cái này giống join
        thongBao5.Replace("Xin chao", "Chao mung"); // Cái này giống replace

        string kq = thongBao5.ToString();
        Console.WriteLine(kq);
    }
}