using JobCandidateHub.API.DataAccess.Repositories;
using JobCandidateHub.API.DataAccess.Repositories.Interfaces;

namespace JobCandidateHub.API.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TheDbContext _context;
        public UnitOfWork(TheDbContext context)
        {
            _context = context;
        }
        public TheDbContext Context => _context;
        private ICandidateRepository _candidateRepository;
        public ICandidateRepository CandidateRepository
        {
            get
            {
                return _candidateRepository ?? (_candidateRepository = new CandidateRepository(_context));
            }
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
