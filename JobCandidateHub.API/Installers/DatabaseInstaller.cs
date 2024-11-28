using JobCandidateHub.API.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace JobCandidateHub.API.Installers
{
    public class DatabaseInstaller : IDependencyInstaller
    {
        public void InstallRequiredServices(WebApplicationBuilder builder)
        {
            //var loggerFactory = LoggerFactory.Create(builder =>
            //{
            //    builder.AddConsole();
            //    builder.AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information);
            //});
            string connectionString = builder.Configuration.GetConnectionString("TheConnectionString");
            builder.Services.AddDbContext<TheDbContext>(options =>
            {
                //additionally use logging mechanisms for generated sql query
                //options.UseLoggerFactory(loggerFactory);
                options.UseSqlServer(connectionString);
            });
        }
    }
}
