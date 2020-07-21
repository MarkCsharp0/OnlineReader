using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace OnlineReader
{
    /// <summary>
    /// Класс настройки хоста.
    /// </summary>
    public static class Program
    {
        /// <summary>
		/// Точка входа в программу.
		/// </summary>
		/// <param name="args">Аргументы командной строки.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
		/// WebHost builder.
        /// </summary>
		/// <param name="args">Command line arguments.</param>
		/// <returns>Configured <see cref="IWebHostBuilder"/> instance.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
