using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace test
{
    public class Program
    {
        public static void Main(string[] args)
        {
           
               Output("Application - Start");
            var webHost = BuildWebHost(args);
            Output("Run WebHost");
           webHost.Run();
            Output("Application - End");
           // BuildWebHost(args).Run();
        }

       // public static iwebhost buildwebhost(string[] args) =>
            //webhost.createdefaultbuilder(args)
              //  .usestartup<startup>()
               // .build();


         public static IWebHost BuildWebHost(string[] args)
        {
            Output("Create WebHost Builder");
            var webHostBuilder = WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    Output("webHostBuilder.ConfigureServices - Called");
                })
                .Configure(app =>
                {
                    Output("webHostBuilder.Configure - Called");
                })
                .UseStartup<Startup>();

            Output("Build WebHost");
            var webHost = webHostBuilder.Build();

            return webHost;
        }

        public static void Output(string message)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}] {message}");
        }
    }
}

    

