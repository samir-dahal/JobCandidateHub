using JobCandidateHub.API.Contracts.Requests;
using JobCandidateHub.API.DataAccess.Models;

namespace JobCandidateHub.API.Extensions
{
    public static class MapRequestToEntityExtension
    {
        public static Candidate ToCandidateEntity(this CandidateRequest request)
        {
            return new Candidate
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                BestTimeToCall = request.BestTimeToCall,
                Comment = request.Comment,
                GitHubProfileUrl = request.GitHubProfileUrl,
                LinkedInProfileUrl = request.LinkedInProfileUrl
            };
        }
    }
}
