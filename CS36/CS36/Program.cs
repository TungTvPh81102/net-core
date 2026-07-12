using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace CS36;

class Program
{
    class MyHttpServer
    {
        public HttpListener listener;

        public MyHttpServer(string[] prifiexs)
        {
            if (!HttpListener.IsSupported)
            {
                throw new Exception("HttpListener not supported");
            }

            listener = new HttpListener();

            foreach (var prefix in prifiexs)
            {
                listener.Prefixes.Add(prefix);
            }
        }

        public async Task Start()
        {
            listener.Start();
            Console.WriteLine("Server started");

            do
            {
                Console.WriteLine(DateTime.Now.ToLongTimeString(), "Watching for requests");
                var context = await listener.GetContextAsync();

                await ProcessRequest(context);

                Console.WriteLine(DateTime.Now.ToLongTimeString(), "Client connected");
            } while (listener.IsListening);
        }

        async Task ProcessRequest(HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            Console.WriteLine($"Request: {request.HttpMethod} {request.RawUrl} {request.Url.AbsolutePath}");
            ;

            var outputStream = response.OutputStream;

            switch (request.Url.AbsolutePath)
            {
                case "/":
                {
                    var buffer = Encoding.UTF8.GetBytes("xin chao cac ban");
                    await outputStream.WriteAsync(buffer, 0, buffer.Length);
                    response.ContentLength64 = buffer.Length;
                }
                    break;

                case "/json":
                {
                    response.Headers.Add("Content-type", "application/json");

                    var product = new
                    {
                        name = "Macbook pro",
                        price = 20000
                    };

                    var json = JsonConvert.SerializeObject(product);

                    var buffer = Encoding.UTF8.GetBytes(json);
                    await outputStream.WriteAsync(buffer, 0, buffer.Length);
                    response.ContentLength64 = buffer.Length;
                }
                    break;
            }

            outputStream.Close();
        }
    }

    static async Task Main(string[] args)
    {
        // if (HttpListener.IsSupported)
        // {
        //     Console.WriteLine("Support ");
        // }
        // else
        // {
        //     Console.WriteLine("No support ");
        // }
        //
        // var server = new HttpListener(); // khoi tao may chu
        //
        // server.Prefixes.Add("http://localhost:8080/"); // cau hinh thuoc tinh cho http listener lam viec
        // server.Start();
        // Console.WriteLine("Server started");
        //
        // do
        // {
        //     var context = await server.GetContextAsync();
        //     var res = context.Response;
        //     var outputStream = res.OutputStream;
        //     Console.WriteLine("Client connect");
        //
        //     res.Headers.Add("content-type", "text/html");
        //
        //     var html = "<h1>hello world</h1>";
        //
        //     var bytes = Encoding.UTF8.GetBytes(html);
        //
        //     await outputStream.WriteAsync(bytes, 0, bytes.Length);
        //
        //     outputStream.Close();
        // } while (server.IsListening);

        // server.Stop(); // pause

        var server = new MyHttpServer(new string[] { "http://*:8080/" });

        await server.Start();
    }
}