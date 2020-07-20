using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace OnlineReader
{
    /// <summary>
    /// ����� ��������� �����.
    /// </summary>
    public static class Program
    {
        /// <summary>
		/// ����� ����� � ���������.
		/// </summary>
		/// <param name="args">��������� ��������� ������.</param>
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
