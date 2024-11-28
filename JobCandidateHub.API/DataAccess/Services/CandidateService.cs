using JobCandidateHub.API.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace JobCandidateHub.API.DataAccess.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CandidateService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Candidate> AddOrUpdateCandidateAsync(Candidate candidate)
        {
            //do not enable no tracking, otherwise entity won't update
            var candidateEntity = await _unitOfWork.CandidateRepository.Get(x => x.Email == candidate.Email, enableNoTracking: false).FirstOrDefaultAsync();
            if(candidateEntity is null)
            {
                candidateEntity = new Candidate
                {
                    FirstName = candidate.FirstName,
                    LastName = candidate.LastName,
                    PhoneNumber = candidate.PhoneNumber,
                    Email = candidate.Email,
                    BestTimeToCall = candidate.BestTimeToCall,
                    Comment = candidate.Comment,
                    GitHubProfileUrl = candidate.GitHubProfileUrl,
                    LinkedInProfileUrl = candidate.LinkedInProfileUrl,
                };
                await _unitOfWork.CandidateRepository.InsertAsync(candidateEntity);
            }
            else
            {
                // Update existing candidate entity
                candidateEntity.FirstName = candidate.FirstName;
                candidateEntity.LastName = candidate.LastName;
                candidateEntity.PhoneNumber = candidate.PhoneNumber;
                candidateEntity.BestTimeToCall = candidate.BestTimeToCall;
                candidateEntity.Comment = candidate.Comment;
                candidateEntity.GitHubProfileUrl = candidate.GitHubProfileUrl;
                candidateEntity.LinkedInProfileUrl = candidate.LinkedInProfileUrl;
            }
            //commit the transaction here
            await _unitOfWork.SaveChangesAsync();
            return candidateEntity;
        }
    }
}
