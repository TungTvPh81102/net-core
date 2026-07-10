namespace CS30;

class Program
{
    public class Product
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string[] Colors { get; set; }

        public int Brand { get; set; }

        public Product(int id, string name, double price, string[] colors, int brand)
        {
            ID = id;
            Name = name;
            Price = price;
            Colors = colors;
            Brand = brand;
        }

        // Lấy chuỗi thông tin sản phẩm gồm ID, Name, Price

        override public string ToString()
            => $"{ID,3} {Name,12} {Price,5} {Brand,2} {string.Join(",", Colors)}";
    }

    public class Brand
    {
        public string Name { get; set; }

        public int ID { get; set; }
    }

    static void Main(string[] args)
    {
        var brands = new List<Brand>()
        {
            new Brand
            {
                ID = 1,
                Name = "Cong ty AAA"
            },
            new Brand
            {
                ID = 2,
                Name = "Cong ty BBB"
            },
            new Brand
            {
                ID = 3,
                Name = "Cong ty CCC"
            }
        };

        var products = new List<Product>()
        {
            new Product(1, "Bàn trà", 400, new string[] { "Xám", "Xanh" }, 2),
            new Product(2, "Tranh treo", 400, new string[] { "Vàng", "Xanh" }, 1),
            new Product(3, "Đèn trùm", 500, new string[] { "Trắng" }, 3),
            new Product(4, "Bàn học", 200, new string[] { "Trắng", "Xanh" }, 1),
            new Product(5, "Túi da", 300, new string[] { "Đỏ", "Đen", "Vàng" }, 2),
            new Product(6, "Giường ngủ", 500, new string[] { "Trắng" }, 2),
            new Product(7, "Tủ áo", 600, new string[] { "Trắng" }, 3),
        };

        // Danh sach san pham co gia 400
        var query = from p in products where p.Price == 400 select p;
        foreach (var p in query)
        {
            Console.WriteLine(p);
        }

        // Select
        var productName = products.Select(p => { return p.Name; });

        foreach (var item in productName)
        {
            Console.WriteLine(item);
        }

        // Where => kiem tra phan tu co chua chuoi tr
        var productNameTr = products.Where(x => { return x.Name.Contains("tr"); });
        foreach (var item in productNameTr)
        {
            Console.WriteLine(item);
        }

        // Select Many: tap hop cua cac chuỗi
        // TH này lấy ra danh sách colors
        // Vì color nó có 1 mảng con nếu dùng Select thì nó sẽ trả về System.String[] nên sẽ dùng SelectMany
        var productSelectMany = products.SelectMany(p => { return p.Colors; });

        foreach (var item in productSelectMany)
        {
            Console.WriteLine(item);
        }

        // Min, Max, Sum, Average

        // Join
        /**
         * Câu phía dưới có nghĩa
         * Join(thamsonguon,dữ kiệu của product cần kết hơp, dữ liệu của brand cần kết hợp)
         */

        // Join(
        //     inner,
        //     outerKeySelector,
        //     innerKeySelector,
        //     resultSelector
        // )

        // Join(
        //     Bảng cần nối,
        //     Key của bảng 1,
        //     Key của bảng 2,
        //     Tạo object kết quả
        // )


        var productByBrand = products.Join(
            brands, // inner collection =>  bảng cần join
            p => p.Brand, // khóa của products => khóa bảng ngoài
            b => b.ID, // khóa của brands => khóa bảng trong
            (p, b) => // sau khi match thì nhận cả 2 object => kết quả
            {
                return new
                {
                    Ten = p.Name,
                    ThuongHieu = b.Name
                };
            });

        foreach (var item in productByBrand)
        {
            Console.WriteLine(item);
        }

        // Group join: hoạt động giống Join nhưng trả về dữ liệu dưới dạng nhóm
        // Giông kiểu left join + group by
        // GroupJoin(
        //     inner,
        //     outerKeySelector,
        //     innerKeySelector,
        //     resultSelector
        // )
        var groupJoin = brands.GroupJoin(products, b => b.ID, p => p.Brand, (b, pros) =>
        {
            return new
            {
                Thuonghieu = b.Name,
                Cacsanpham = pros
            };
        });

        foreach (var item in groupJoin)
        {
            Console.WriteLine(item.Thuonghieu);
            foreach (var p in item.Cacsanpham)
            {
                Console.WriteLine(p);
            }
        }

        // Take: lấy ra n số sản phẩm 
        // Dùng để lâ n bản ghi đầu từ 1 tập dữ liệu
        // Nó giống câu select TOP(4) trong sql
        var take = products.Take(4);
        foreach (var item in take)
        {
            Console.WriteLine("========== TAKE ==========");
            Console.WriteLine(item);
        }

        products.Take(1).OrderBy(x => x.Price).ToList().ForEach(p => Console.WriteLine(p));

        // Skip 
        // Bỏ qua n phần tử đầu và lấy các phần tử còn lại
        products.Skip(1).OrderBy(x => x.Price).ToList().ForEach(p => Console.WriteLine(p));

        // OrderBy (tăng dần) / OrderByDescending (giảm dần)
        products.OrderByDescending(x => x.Price).ToList().ForEach(p => Console.WriteLine(p)); // sắp xếp giá giảm dần

        // Reverse: sắp xếp đảo ngược
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        numbers.ToList().ForEach(p => Console.WriteLine(p));
        Console.WriteLine("Sap xep dao nguoc");
        numbers.Reverse().ToList().ForEach(p => Console.WriteLine(p));

        // GroupBy: tra ve 1 tập hợp, nhóm theo giá trị, chia 1 collection thành nhiêều nho
        // nó giống như câu truy vấn groupby
        var groupBy = products.GroupBy(p => p.Price);
        foreach (var group in groupBy)
        {
            Console.WriteLine(group.Key);
            foreach (var p in group)
            {
                Console.WriteLine(p);
            }
        }

        // Distinct
        var distinct = products.SelectMany(p => p.Colors).Distinct();
        foreach (var item in distinct)
        {
            Console.WriteLine(item);
        }

        // Single / SingleOrDefault
        // Kiểm tra xem có thỏa mãn điều kiên logic k
        // Có thì trả về phần tử đó, k có hoặc >= 2 giá trị thì error => Single
        // SingleOrDefault cũng giống với Single, tuy nhiên dùng cái này nếu k có dữ liệu thì sẽ k xay ra lỗi, k tìm thấy sẽ tra về null

        var single = products.SingleOrDefault(p => p.Price == 600);
        if (single != null)
            Console.WriteLine(single);

        // Any -> sẽ trả về true nếu thỏa mãn điều kiện giống với EXISTS trong sql
        // K thỏa mãn thì trả về false
        var any = products.Any(p => p.Price == 60000);
        Console.WriteLine(any);

        // All -> nó cũng trả về true và fales
        // Tuy nhiên phải thỏa mãn điều kiện => true
        // 1 phẩn tử k thỏa mãn => false
        var all = products.All(p => p.Price >= 0);
        Console.WriteLine(all);

        // Count() -> đếm all sản phẩm có trong products
        // Có thể gộp điều kiện
        var count = products.Count(x => x.Price >= 300);
        Console.WriteLine(count);

        var qr = from p in products
            from c in p.Colors
            where p.Price <= 500 && c == "Xanh"
            orderby p.Price descending
            select new
            {
                Ten = p.Name,
                Gia = p.Price,
                CacMau = p.Colors,
            };

        qr.ToList().ForEach(p =>
        {
            Console.WriteLine(p.Ten);
            string.Join(",", p.CacMau); // Nối chuỗi
        });

        // Nhóm sp theo giá
        var groupPrice = from p in products
            group p by p.Price;

        groupPrice.ToList().ForEach(g =>
        {
            Console.WriteLine(g.Key);
            foreach (var items in g)
            {
                Console.WriteLine(items.Name);
            }
        });

        // let trong linq
        // Có thể khai báo let trực tiếp trong câu linq

        var checkLet = from p in products
                group p by p.Price
                into gr
                orderby gr.Key
                let sl = "So luong la" + gr.Count()
                select new
                {
                    Ten = gr.Key,
                    Cacsanpham = gr.ToList(),
                    Soluong = sl
                }
            ;

        checkLet.ToList().ForEach(p => Console.WriteLine(p.Ten + p.Soluong));
        
        // Join viết trực tiếp trong linq
        // BT trong sql sẽ dùng on nhung ở đây sẽ dùng equals tương tự với on
        var checkJoin = from product in products
            join brand in brands on product.Brand equals brand.ID
            select new
            {
                Ten = product.Name,
                Gia = product.Price,
                Thuonghieu = product.Colors,
            };
        
        foreach (var c in checkJoin)
        {
            Console.WriteLine($"{c.Ten} {c.Gia} {c.Thuonghieu}");
        }
    }
}

// Linq
// Nguon du lieu: IEnumerable, IEnumerable<T> (Array, List, Stack, Queue,...)