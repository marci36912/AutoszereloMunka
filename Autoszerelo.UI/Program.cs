using Autoszerelo.UI.Services;
using Autoszerelo.UI.Services.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Autoszerelo.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7101") });
            builder.Services.AddScoped<IUgyfelService, UgyfelService>();
            builder.Services.AddScoped<IMunkaService, MunkaService>();

            await builder.Build().RunAsync();
        }
    }
}
