using JobCandidateHub.API.DataAccess.Repositories.Interfaces;

namespace JobCandidateHub.API.DataAccess
{
    public interface IUnitOfWork
    {
        TheDbContext Context { get; }
        ICandidateRepository CandidateRepository { get; }
        Task SaveChangesAsync();
    }
}
