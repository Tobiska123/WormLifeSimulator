using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace WormLifeSimulator
{
    class Program
    {
        public static void Main(string[] args)
        {

            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args)

        {



            return Host.CreateDefaultBuilder(args)

                .ConfigureServices((hostContext, services) =>

                {
                    services.AddHostedService<Simulator>();
                    // Служба симулятора мира
                    services.AddScoped<IFoodGenerator, FoodGenerator>();
                    services.AddScoped<INameGenerator, NameGenerator>();
                    services.AddScoped<IWormLogic, StupidLogic>();
                    services.AddScoped<ILogger, OutputFileWriter>();

                });

        }

    }
}
