namespace JobCandidateHub.API.Installers
{
    public static class InstallerExtension
    {
        /// <summary>
        /// Just a extenstion method to query and install all the available depdency i have, just for the separation
        /// </summary>
        /// <param name="builder"></param>
        public static void InstallRequiredServices(this WebApplicationBuilder builder)
        {
            //this will call the "InstallRequiredServices" method of every depdency that implements the IDepdencyInstaller
            var services = typeof(Program).Assembly.ExportedTypes
                .Where(x => typeof(IDependencyInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IDependencyInstaller>()
                .ToList();

            services.ForEach(service => service.InstallRequiredServices(builder));
        }
    }
}
