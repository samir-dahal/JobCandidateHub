using JobCandidateHub.API.DataAccess.Services;

namespace JobCandidateHub.API.Installers
{
    public class ServiceInstaller : IDependencyInstaller
    {
        public void InstallRequiredServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICandidateService, CandidateService>();
        }
    }
}
