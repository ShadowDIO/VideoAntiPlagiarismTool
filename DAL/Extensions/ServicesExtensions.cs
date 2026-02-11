using DAL.Implementation;
using DAL.Interfaces;
using DAL.Models.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Extensions
{
    public static class ServicesExtensions
    {
        public static void RegisterDALs(this IServiceCollection services, string connectionString)
        {
            services.AddDbContextFactory<VideoScriptAntiplagiarismContext>(options =>
            {
                options.UseMySQL(connectionString);
            });

            services.AddScoped<IVideoInformationDAL, VideoInformationDAL>();
        }
    }
}
