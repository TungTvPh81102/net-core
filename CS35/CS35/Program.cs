using System.Net;

namespace CS35;

class Program
{
    static async Task Main(string[] args)
    {
        var url = "https://postman-echo.com/post";

        var cokies = new CookieContainer();
        
        using var handler = new SocketsHttpHandler();
        handler.AllowAutoRedirect = true; // cho phep chuyen huong khi ma tra ve laf 301
        handler.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
        handler.UseCookies = true; //  cookie
        handler.CookieContainer = cokies;
        
        
        using var client = new HttpClient(handler);

        using var httpRequestMessage = new HttpRequestMessage();
        httpRequestMessage.Method = HttpMethod.Post;
        httpRequestMessage.RequestUri = new Uri(url);
        httpRequestMessage.Headers.Add("User-Agent", "Mozilla/5.0");

        var paraeters = new List<KeyValuePair<string, string>>();

        paraeters.Add(new KeyValuePair<string, string>("key1", "value1"));
        paraeters.Add(new KeyValuePair<string, string>("key1", "value1"));


        httpRequestMessage.Content = new FormUrlEncodedContent(paraeters);

        var res = await client.SendAsync(httpRequestMessage);

        cokies.GetCookies(new Uri(url)).ToList().ForEach(c =>
        {
            Console.WriteLine($"{c.Name}: {c.Value}");
        });
        
        var html = res.Content.ReadAsStringAsync().Result;
        
        Console.WriteLine(html);
    }
}