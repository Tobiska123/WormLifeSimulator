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
                    services.AddScoped<IWorldBeheviorManager, WorldBeheviorManager>();
                    services.AddScoped<IFoodGenerator>(provider => {
                        IWorldBeheviorManager worldService = provider.GetService<IWorldBeheviorManager>();
                        if(worldService.Exist(args[0]))
                        {
                            return new LoadFood(args[0], worldService);
                        }
                        else
                        {
                            return new FoodGenerator(args[0], worldService);
                        }
                       
                    });
                    services.AddScoped<INameGenerator, NameGenerator>();
                    services.AddScoped<IWormLogic, StupidLogic>();
                    services.AddScoped<ILogger, OutputFileWriter>();
                    services.AddDbContext<AppContext>();
                });

        }

    }
}
