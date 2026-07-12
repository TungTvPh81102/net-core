using System.Net;
using System.Net.NetworkInformation;

namespace CS34;

class Program
{
    static void Main(string[] args)
    {
        // string url = "https://xuanthulab.net/lap-trinh/csharp/?page=3#acff";
        // var uri = new Uri(url);
        //
        // var uritype = typeof(Uri);
        // uritype.GetProperties().ToList().ForEach(property => {
        //     Console.WriteLine($"{property.Name, 15} {property.GetValue(uri)}");
        // });
        // Console.WriteLine($"Segments: {string.Join(",", uri.Segments)}");

        var hostname = Dns.GetHostName();
        Console.WriteLine(hostname);

        var url = "https://www.youtube.com/";

        var uri = new Uri(url);

        Console.WriteLine(uri);

        var ipHostEntry = Dns.GetHostEntry(uri.Host);

        Console.WriteLine(ipHostEntry.HostName);

        // ipHostEntry.AddressList se tra ve danh sach dia chi IP
        ipHostEntry.AddressList.ToList().ForEach(x => { Console.WriteLine(x); });

        var ping = new Ping();

        var pingReply = ping.Send("www.youtube.com");
        if (pingReply.Status == IPStatus.Success) // thuoc tinh ping dc thanh cong se tra ve success
        {
            Console.WriteLine("============");
            Console.WriteLine(IPStatus.Success);
            Console.WriteLine(pingReply.RoundtripTime);
            Console.WriteLine(pingReply.Address);
        }

        var url2 = "https://www.youtube.com/watch?v=iJlAMzFy4yQ&list=PLwJr0JSP7i8BERdErX9Ird67xTflZkxb-&index=34";

        var task = GetWebContent(url2);
        task.Wait();

        var html =  task.Result;
        
        Console.WriteLine(html);
    }

    public static async Task<string> GetWebContent(string url)
    {
        using var httpClient = new HttpClient();

        HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);

        string html = await httpResponseMessage.Content.ReadAsStringAsync();

        return html;
    }
}

// httpclient