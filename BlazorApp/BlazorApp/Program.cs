using BlazorApp.Util;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorApp
{
    public class Program
    {
        public static IConfiguration Configuration { get; set; }
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            var Url = builder.Configuration.GetSection("ClientApi:BaseUrl").Value;
            Logger.Log("Api Url"+Url);
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5041/api/") });

            await builder.Build().RunAsync();
        }
    }
}
