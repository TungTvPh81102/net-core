using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CS33;

class Program
{
    interface IClassB
    {
        public void ActionB();
    }

    interface IClassC
    {
        public void ActionC();
    }

    class ClassC : IClassC
    {
        public ClassC() => Console.WriteLine("ClassC is created");
        public void ActionC() => Console.WriteLine("Action in ClassC");
    }

    class ClassB : IClassB
    {
        IClassC c_dependency;

        public ClassB(IClassC classc)
        {
            c_dependency = classc;
            Console.WriteLine("ClassB is created");
        }

        public void ActionB()
        {
            Console.WriteLine("Action in ClassB");
            c_dependency.ActionC();
        }
    }


    class ClassA
    {
        IClassB b_dependency;

        public ClassA(IClassB classb)
        {
            b_dependency = classb;
            Console.WriteLine("ClassA is created");
        }

        public void ActionA()
        {
            Console.WriteLine("Action in ClassA");
            b_dependency.ActionB();
        }
    }

    class ClassC1 : IClassC
    {
        public ClassC1() => Console.WriteLine("ClassC1 is created");

        public void ActionC()
        {
            Console.WriteLine("Action in C1");
        }
    }

    class ClassB1 : IClassB
    {
        IClassC c_dependency;

        public ClassB1(IClassC classc)
        {
            c_dependency = classc;
            Console.WriteLine("ClassB1 is created");
        }

        public void ActionB()
        {
            Console.WriteLine("Action in B1");
            c_dependency.ActionC();
        }
    }

    class ClassB2 : IClassB
    {
        IClassC c_dependency;
        string message;

        public ClassB2(IClassC classc, string mgs)
        {
            c_dependency = classc;
            message = mgs;
            Console.WriteLine("ClassB2 is created");
        }

        public void ActionB()
        {
            Console.WriteLine(message);
            c_dependency.ActionC();
        }
    }


    static IClassB CreateB2(IServiceProvider provider)
    {
        var b2 = new ClassB2(
            provider.GetService<IClassC>(),
            "thuc hien trong classb2"
        );
        return b2;
    }

    public class MyServiceOptions
    {
        public string data1 { set; get; }
        public string data2 { set; get; }
    }

    public class MyService
    {
        public string data1 { set; get; }
        public string data2 { set; get; }

        public MyService(IOptions<MyServiceOptions> options)
        {
            var _options = options.Value;
            data1 = _options.data1;
            data2 = _options.data2;
        }

        public void PrintData()
        {
            Console.WriteLine(data1 + data2);
        }
    }


    static void Main(string[] args)
    {
        var services = new ServiceCollection();

        // dang ky cac dịch vụ
        // IClassC , ClassC, ClassC1

        // dang ky kieu singleton -> chỉ là 1 đối tượng duy nhất
        // services.AddSingleton<IClassC, ClassC>(); // nó kiểu như thêm type và function vào ý 

        // dang ky kieu Transient -> mỗi lần gọi dịch vụ sẽ có 1 đối tượng mới tạo ra
        // services.AddTransient<IClassB, ClassB>();

        // dang ky kieu scoped -> trong mooi phạm vi chỉ có 1 đối tượng tạo ra 
        // services.AddScoped<IClassC, ClassC>();

        // var provider = services.BuildServiceProvider();

        // lấy ra các đối tg được đăng ký trong servicecollecction

        // var a = provider.GetService<TenService>();

        // var classC = provider.GetService<IClassC>();

        // kieu singleton
        // for (int i = 0; i < 5; i++)
        // {
        //     IClassC c = provider.GetService<IClassC>();
        //
        //     Console.WriteLine(c.GetHashCode()); //  tạo ra mã hash
        // }
        //
        // // kieu Transient
        // for (int i = 0; i < 5; i++)
        // {
        //     // khi gọi Transient thì ở đây sẽ có 5 lần khởi tạo đối tượng class b
        //     // giống với việc tạo new ClassB 5 lần
        //     IClassB b = provider.GetService<IClassB>();
        //
        //     Console.WriteLine(b.GetHashCode()); //  tạo ra mã hash
        // }
        //
        // // khoi tao  scope
        // using (var scope = provider.CreateScope())
        // {
        //     var provider1 = scope.ServiceProvider;
        //     for (int i = 0; i < 5; i++)
        //     {
        //         IClassC c = provider1.GetService<IClassC>();
        //
        //         Console.WriteLine(c.GetHashCode());
        //     }
        // }

        Console.WriteLine("===========================");

        // đăng ký dịch vụ
        services.AddSingleton<ClassA, ClassA>();
        services.AddSingleton<IClassB>(CreateB2);
        services.AddSingleton<IClassC, ClassC1>();
        services.AddSingleton<string, string>();

        services.AddSingleton<MyService>();
        
        IConfigurationRoot configurationRoot;
        ConfigurationBuilder
            configurationBuilder = new ConfigurationBuilder(); // khởi tạo config builder nạp các file cấu hình

        configurationBuilder.SetBasePath(Directory
            .GetCurrentDirectory()); // Directory.GetCurrentDirectory() lấy thông tin path thư mục hiện tại    
        configurationBuilder.AddJsonFile("config.json");

        configurationRoot = configurationBuilder.Build();
        
        var sectionMyServiceOptions = configurationRoot.GetSection("MyServiceOptions");

        services.Configure<MyServiceOptions>(options =>
        {
            // options.data1 = "xin chao";
            // options.data2 = "2026";
        });
        
        services.Configure<MyServiceOptions>(sectionMyServiceOptions);
        

        var provider = services.BuildServiceProvider();

        ClassA x = provider.GetService<ClassA>();

        x.ActionA();

        var myService = provider.GetService<MyService>();
        myService.PrintData();


        var key1 = configurationRoot.GetSection("section1").GetSection("key1").Value;
        
        Console.WriteLine(key1);
        
        var data1 = configurationRoot.GetSection("MyServiceOptions").GetSection("data1").Value;
        Console.WriteLine(data1);
        
        
    }
}

// Dependency injection 
// Dependency => sự phụ thuộc

// có thể inject thông qua setter, interface

// thư viện dependency inject
// DI Container: ServiceCollection
// - dang ky cac dich vu lop
// - ServiceProvider -> get server: cho phép lấy sự kiện đc đăng ký trong ServiceCollection  
// - sử dụng Microsoft.Extensions.DependencyInjection
// - Singleton => duy nhất 1 phiên bản thực thi của dịch vụ chạy cho hết vòng đời của ServiceProvider
// - Scoped => trong mỗi phạm vi tạo bởi ServiceProvider có 1 phiên bản được dùng 
// - Transient => 1 phiên bản của dịch vụ đc tạo mỗi khi được gửi yêu cầu
// Khi khởi tạo var services = new ServiceCollection(); sẽ có
// - AddSingleton<ServiceType, ImplementationType>()
// - AddSingleton<ServiceType>()
// - AddTransient<ServiceType, ImplementationType>()
// - AddTransient<ServiceType>()
// - AddScoped<ServiceType, ImplementationType>()
// - BuildServiceProvider() => sinh ra 1 lớp serviceprovider 
// - Từ lớp serviceprovider = services.BuildServiceProvider(); có thể gọi các phương thức:
// -- GetService<ServiceType>()
// -- GetRequiredService(ServiceType)
// -- CreateScope()

// AddSingleton => thường dùng cho việc cache và config