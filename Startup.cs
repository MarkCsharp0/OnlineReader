using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace OnlineReader
{
    /// <summary>
    /// Application startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
		/// Initialize new instance of <see cref="Startup"/>.
		/// </summary>
		/// <param name="configuration">Application configuration.</param>

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Application configuration.
		/// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
		/// Настраивает сервисы приложения.
		/// </summary>
		/// <param name="services">Коллекция сервисов.</param>
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        /// <inheritdoc cref="IStartup.Configure" />
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
