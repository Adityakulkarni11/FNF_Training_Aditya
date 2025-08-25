using System;
using Microsoft.Extensions.Configuration;
namespace SampleConApp
{
    internal class Ex25ReadingConfig
    {
        public static IConfiguration AppConfig { get; private set; }
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            AppConfig = config;

            var appName = AppConfig["AppSettings:AppName"];
            var title = AppConfig["AppSettings:Title"];

            Console.WriteLine($"~~~~~~~~~~{appName.ToUpper()}~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"~~~~~~~~~~{title.ToUpper()}~~~~~~~~~~~~~~~~~~~");
            Console.ReadKey();

            var appSettings = new AppSettings();
            config.GetSection("AppSettings").Bind(appSettings);//Bind the configuration section to the AppSettings class
            Console.WriteLine(appSettings.Title);

        }
    }
    class AppSettings
    {
        public string AppName { get; set; }
        public string Title { get; set; }
    }
}
