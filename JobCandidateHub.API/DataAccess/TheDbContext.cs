using JobCandidateHub.API.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace JobCandidateHub.API.DataAccess
{
    public class TheDbContext : DbContext
    {
        public TheDbContext(DbContextOptions<TheDbContext> options) : base(options)
        {

        }
        public DbSet<Candidate> Candidates { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //setup unique index on candidate's Email
            builder.Entity<Candidate>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
