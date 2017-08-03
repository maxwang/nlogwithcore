using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace NlogConfigByServices
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddLogging();
            var provider = services.BuildServiceProvider();

            var factory = provider.GetService<ILoggerFactory>();
            factory.AddNLog();
            factory.ConfigureNLog("Nlog.config");

            var logger = provider.GetService<ILogger<Program>>();
            logger.LogCritical("hello nlog");
            
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}