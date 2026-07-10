using System;

namespace CS26
{
    class Program
    {
        public static void Main(string[] args)
        {
            Queue<string> cacHoSo = new Queue<string>();

            cacHoSo.Enqueue("Ho so 1");
            cacHoSo.Enqueue("Ho so 2");
            cacHoSo.Enqueue("Ho so 3");

            foreach (var items in cacHoSo)
            {
                Console.WriteLine(items);
            }

            // Loại bỏ phần từ đầu tiên của hàng đợi
            var hoso = cacHoSo.Dequeue();
            Console.WriteLine($"Xu ly ho so: {hoso} - {cacHoSo.Count}");

            hoso = cacHoSo.Dequeue();
            Console.WriteLine($"Xu ly ho so: {hoso} - {cacHoSo.Count}");

            hoso = cacHoSo.Dequeue();
            Console.WriteLine($"Xu ly ho so: {hoso} - {cacHoSo.Count}");


            Stack<string> hangHoa = new Stack<string>();
            hangHoa.Push("Mat hang 1");
            hangHoa.Push("Mat hang 2");
            hangHoa.Push("Mat hang 3");

            var mathang = hangHoa.Pop(); // loai bo phần tử đỉnh Stack
            Console.WriteLine(mathang);

            mathang = hangHoa.Pop(); // loai bo phần tử đỉnh Stack
            Console.WriteLine(mathang);

            mathang = hangHoa.Pop(); // loai bo phần tử đỉnh Stack
            Console.WriteLine(mathang);

            Console.WriteLine("===============");

            LinkedList<string> baiHoc = new LinkedList<string>();
            var bh1 = baiHoc.AddFirst("Bai hoc 1");
            var bh3 = baiHoc.AddLast("Bai hoc 3");
            LinkedListNode<string> bh2 = baiHoc.AddAfter(bh1, "Bai hoc 2");

            baiHoc.AddLast("Bai hoc 4");
            var bh6 = baiHoc.AddLast("Bai hoc 6");
            baiHoc.AddBefore(bh6, "Bai hoc 5");

            foreach (var items in baiHoc)
            {
                Console.WriteLine(items);
            }

            Console.WriteLine("===============");
            var node = bh2;

            Console.WriteLine(node.Next.Value); // Lấy nút dữ liệu phía sau bh2
            Console.WriteLine(node.Previous.Value); // Lấy nút dữ liệu phía trước bh2

            Console.WriteLine("===============");
            Dictionary<string, int> sodem = new Dictionary<string, int>()
            {
                ["one"] = 1,
                ["two"] = 2,
            };

            sodem["three"] = 3;

            var keys = sodem.Keys;
            foreach (var k in keys)
            {
                var value = sodem[k];
                Console.WriteLine($"{k} = {value}");
            }

            foreach (KeyValuePair<string, int> item in sodem)
            {
                Console.WriteLine($"{item.Key} = {item.Value}");
            }

            Console.WriteLine("===============");

            HashSet<int> set1 = new HashSet<int>() { 1, 2, 3, 5, 6, 7 };
            HashSet<int> set2 = new HashSet<int>() { 8, 9, 1, 2, 6, 7, 10 };

            set1.Add(10);
            set2.Remove(7);

            set1.UnionWith(set2); // Gộp set1 với set2
            foreach (var items in set1)
            {
                Console.WriteLine(items);
            }
            
            Console.WriteLine("===============");
            set1.IntersectWith(set2); // giu lại phần tử giống nhau của 2 tâp
            foreach (var items in set1)
            {
                Console.WriteLine(items);
            }
            
        }
    }
}

// Queue, Stack, LinkedList, Dictionary, HashSet

/**
 * HashSet - tập hợp danh sách không cho phép giá trị trùng nhau - HashSet<T>
 * Add(T) => thêm phần tử vao HashSet
 * Remove(T) => xóa phần tử khoi HashSet
 * IsSubsetOf(c) => kiem tra xem có tập con của HashSet c
 * IsSupersetOf(c) => kiem tra xem co chua tap HashSet c
 * UnionWith(c) => hơp với tập HashSet c nghĩa là hợp nhất chúng lại với nhau, loại bỏ đi những dữ liệu trùng
 * IntersectWith(c) => giao với tập HashSet c nghia là sẽ lấy ra những phần tử giống nhau
 * ExceptWith(c) => loại bỏ các phần tử chung với c
 */

/**
 * Dictionary<Tkey,TValue>
 * [key] => indexer truy cập đến phần tử có key
 * Keys => thuộc tính là danh sách các key
 * Values => thộc tính lấy danh sách các giá trị
 * Add(key,value) => thêm 1 phần tử vào Dictinory
 * Remove(key) => xóa 1 phần tử bằng key của chính n
 * ContainKey(key) => kiểm tra phần từ nào có khóa là key
 * ContainValue(value) => kiểm tra phần tử có giá trị value
 */

/**
 * Enqueue => đưa phần tử vào cuối hàng đợi
 * Dequeue => đọc và loại ngay phần tử ở đầu hàng đợi
 * Peek => đọc phần tử đầu hàng đợi => giống FIFO
 */

/**
 * Stack => kiểu dữ liệu sắp xếp vào sau ra trước - đc triển khai bằng lớp Stack
 * Push => thêm 1 phần tử vào đỉnh của Stack
 * Pop => đọc và loại bỏ phần tử đình Stack
 * Peek => đọc phần tử đỉnh Stack
 * Contains => Kiểm tra phần tử có trong Stack không
 */


// Queue -> vào trc ra trước 
// Stack -> vào sau ra trước

/**
 * LinkedList - triển khai bằng LinkedList<T>
 * List => tham chiếu trỏ đến LinkedList
 * Value => là dữ liệu của node
 * Next => tham chiếu trỏ đến nút tiếp theo -> null thì là nút cuối
 * Pervious => tham chiếu trỏ đến nút phía trước -> null thì là nút đầu
 * AddFirst => thêm vao đầu danh sách
 * AddLast => thêm vào cuối danh sách
 * AddAfter(Node,T) => chén nút với dữ liệu T vào sau nút Node
 * AddBefore(Node,T) => chèn nút với dữ liệu T vào trước nút Node
 * Clear() => xóa toàn bộ danh sách
 * RemoveFirst() => xóa node đầu tiên
 * RemoveLast() => xoa node cuối cùng
 * Find => tim kiếm 1 node
 */