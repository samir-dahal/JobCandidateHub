using JobCandidateHub.API.DataAccess.Models;
using JobCandidateHub.API.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobCandidateHub.API.DataAccess.Repositories
{
    public class CandidateRepository : Repository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(DbContext context) : base(context)
        {
        }
    }
}
