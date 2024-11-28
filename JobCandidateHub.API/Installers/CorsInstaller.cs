namespace JobCandidateHub.API.Installers
{
    /// <summary>
    /// Needed this because browsers by default block the API request from frontend to third party servers
    /// </summary>
    public class CorsInstaller : IDependencyInstaller
    {
        public void InstallRequiredServices(WebApplicationBuilder builder)
        {
            //for now just adding this as public so any frontend app can call this api
            //in future we can add custom origins to filter out the domains
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowPublicAPI",
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .Build()
                );
            });
        }
    }
}
