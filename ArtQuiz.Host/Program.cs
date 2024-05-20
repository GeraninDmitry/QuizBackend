using Serilog;

namespace ArtQuiz.Host
{
    public class Program
    {
        public static async Task Main(string[] args) => await CreateHostBuilder(args).Build().RunAsync();

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
                .UseSerilog(
                    (whb, ctx) =>
                        ctx.ReadFrom.Configuration(whb.Configuration)
                            .Enrich.FromLogContext()
                )
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
    }
}