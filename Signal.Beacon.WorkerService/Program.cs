using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Signal.Beacon.Application;
using Signal.Beacon.Configuration;
using Signal.Beacon.PhilipsHue;
using Signal.Beacon.Processor;
using Signal.Beacon.Zigbee2Mqtt;

namespace Signal.Beacon.WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                {
                    services
                        .AddHostedService<Worker>()
                        .AddBeaconConfiguration()
                        .AddBeaconApplication()
                        .AddBeaconProcessor()
                        .AddZigbee2Mqtt()
                        .AddPhilipsHue();
                });
    }
}
