using JobCandidateHub.API.DataAccess.Models;

namespace JobCandidateHub.API.DataAccess.Services
{
    public interface ICandidateService
    {
        Task<Candidate> AddOrUpdateCandidateAsync(Candidate candidate);
    }
}
