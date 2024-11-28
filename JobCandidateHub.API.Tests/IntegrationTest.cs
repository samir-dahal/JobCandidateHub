using JobCandidateHub.API.DataAccess;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace JobCandidateHub.API.Tests
{
    public class IntegrationTest
    {
        protected readonly HttpClient Client;
        public IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(TheDbContext));
                        services.AddDbContext<TheDbContext>(options =>
                        {
                            options.UseInMemoryDatabase("JobCandidateHubDb");
                        });
                    });
                });
            Client = appFactory.CreateClient();
        }
    }
}
