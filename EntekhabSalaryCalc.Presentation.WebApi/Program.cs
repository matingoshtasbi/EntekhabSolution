namespace EntekhabSalaryCalc.Presentation.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string env = Environment.GetEnvironmentVariable("ENV") ?? "dev";

            var host = CreateHostBuilder(args, env).Build();

            //CreateDbIfNotExists(host);

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args, string env)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                 {
                     //config.AddJsonFile(
                     //    context.HostingEnvironment.ContentRootPath + $"/Config/appsettings-{env}.json",
                     //    false, false);
                 })

                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}
