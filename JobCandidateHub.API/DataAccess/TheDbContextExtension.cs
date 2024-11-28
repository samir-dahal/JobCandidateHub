using Microsoft.EntityFrameworkCore;

namespace JobCandidateHub.API.DataAccess
{
    public static class TheDbContextExtension
    {
        public static void MigrateData(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<TheDbContext>();
                context.Database.Migrate();
            }
        }
    }
}
