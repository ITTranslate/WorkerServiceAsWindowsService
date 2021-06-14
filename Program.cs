using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace MyService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // 作为 Windows Service 运行时，默认的当前工作目录是 C:\WINDOWS\system32，会导致找不到配置文件，所以需要添加一行。
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Production"}.json", true)
                .Build();

            // 全局共享的日志记录器
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .CreateLogger();

            try
            {
                // // test log.
                // var position = new { Latitude = 25, Longitude = 134 };
                // var elapsedMs = 34;
                // Log.Information("Processed {@Position} in {Elapsed:000} ms.", position, elapsedMs);

                var separator = new string('-', 30);

                Log.Information($"{separator} Starting host {separator} ");

                CreateHostBuilder(args).Build().Run();

                Log.Information($"{separator} Exit host {separator} ");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush(); // 释放资源
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService() // Sets the host lifetime to WindowsServiceLifetime...
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                })
                .UseSerilog(); //将 Serilog 设置为日志提供程序
    }
}