namespace JobCandidateHub.API.Installers
{
    public interface IDependencyInstaller
    {
        void InstallRequiredServices(WebApplicationBuilder builder);
    }
}
