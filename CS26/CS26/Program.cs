using System;

namespace CS26
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<int> ds1 = new List<int>()
            {
                7, 8, 9
            }; // có thể khởi tạo phần tử luôn bằng cách đưa phần tử vào trong {}

            ds1.Add(1);
            ds1.Add(2);
            ds1.AddRange(new int[] { 3, 4, 5 });

            ds1.Insert(0, 10);
            // Console.WriteLine(ds1.Count);

            ds1.RemoveAt(7); // Chỉ xóa số index
            ds1.Remove(0); // Xóa giá trị cụ thể đầu tiên khi bắt gặp

            foreach (var items in ds1)
            {
                Console.WriteLine(items);
            }

            List<int> ds2 = new List<int>()
            {
                30, 31, 33, 34, 35, 36
            };

            var n = ds2.Find(x => { return x % 2 == 0; });
            Console.WriteLine(n);

            var n2 = ds2.FindAll(x => { return x >= 34; });

            foreach (var items in n2)
            {
                Console.WriteLine("Find all cua n2 là: " + items);
            }

            Console.WriteLine("==============================");

            /*
             * VD: Khởi tạo list có kiểu Product
             */
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    name = "Ipad", price = 100, id = 1, origin = "VN"
                },
                new Product()
                {
                    name = "SamSung", price = 900, id = 2, origin = "TQ"
                },
                new Product()
                {
                    name = "Sony", price = 1000, id = 3, origin = "NB"
                },
                new Product()
                {
                    name = "Nokia", price = 100, id = 4, origin = "TQ"
                },
            };

            // Tìm sản phẩm đầu tiên xuất xử tại NB
            var nb = products.Find(x => { return x.origin == "NB"; });

            if (nb != null)
            {
                Console.WriteLine($"{nb.name} - {nb.price} - {nb.origin}");
            }

            // Tìm sp có giá <=900
            var sp = products.FindAll(x => { return x.price <= 900; });

            if (sp != null)
            {
                Console.WriteLine("Danh sach sp co gia <= 900");
                foreach (var items in sp)
                {
                    Console.WriteLine($"{items.name} - {items.price} - {items.origin}");
                }
            }

            Console.WriteLine("==============================");
            // Tìm sp có name bắt đầu bằng chữ S và viết in hoa trong danh sách
            var nameS = products.FindAll(x => { return x.name.ToUpper().StartsWith("S"); });

            if (nameS != null)
            {
                foreach (var items in nameS)
                {
                    Console.WriteLine("Danh sach bat dau bang chu S");
                    Console.WriteLine($"{items.name} - {items.price} - {items.origin}");
                }
            }
            else
            {
                Console.WriteLine("Khong tim thay phan tu nao");
            }

            Console.WriteLine("==============================");
            // Sắp xếp phần tử
            foreach (var items in products)
            {
                Console.WriteLine("Danh sach ban dau cua ban tu");
                Console.WriteLine($"{items.name} - {items.price} - {items.origin}");
            }

            products.Sort((x, y) =>
            {
                if (x.price == y.price)
                {
                    return 0;
                }
                else if (x.price < y.price)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            });

            Console.WriteLine("Sap xep gia san pham tu cao xuong thap");
            foreach (var items in products)
            {
                Console.WriteLine("Danh sach ban dau sau khi sap xep");
                Console.WriteLine($"{items.name} - {items.price} - {items.origin}");
            }

            Console.WriteLine("==============================");
            Console.WriteLine("SortedList");
            SortedList<string, Product> productsS = new SortedList<string, Product>();
            productsS["sanpham1"] = new Product()
            {
                name = "SamSung", price = 100, origin = "VN"
            };
            productsS["sanpham2"] = new Product()
            {
                name = "Iphone", price = 100, origin = "VN"
            };
            productsS.Add("sanpham3", new Product()
            {
                name = "Nokia", price = 100, origin = "VN"
            });

            var p = productsS["sanpham3"];
            Console.WriteLine(p.name);

            var keys = productsS.Keys;
            var values = productsS.Values;

            foreach (KeyValuePair<string, Product> item in productsS)
            {
                var key = item.Key;
                var value = item.Value;

                Console.WriteLine($"{key} - {value.name}");
            }

            productsS.Remove("sanpham3");
        }
    }
}

// Kiểu dữ liệu danh sách List và SortedList
// add() => gọi để thêm 1 phần tử vào danh sách
// addRange() => thêm 1 mảng danh sách phần tử
// count => đếm số phần tử của danh sách
// insert(index,giá trị) => chèn phần tử vào vị trí x trong danh sách
// insertRage => chèn 1 nhóm phần tử vào danh sách
// removeAt(index) => xóa đi 1 phần tử trong bảng theo index
// remove(giá trị) => xóa giá trị cụ thể của phần tử, giá trị đầu khi bắt gặp nếu bị trùng
// removeAll or clear => xóa tất cả các phần tử

// find => tìm kiếm và trả về phần tử đầu tiên trong danh sách thỏa mãn
// findAdd => tìm kiếm và trả về tập hợp danh sách phần tử thỏa mãn => hiển thị bằng cách duyệt mảng

// startsWith => tìm kiếm ký tự đầu tiên trong danh sách
// sort => sắp xếp giá trị
// storedList => khởi tạo dưới dạng key values SortedList<key, giá trị> => lấy giá trị thông qua foreach KeyValuePair<string, Product>