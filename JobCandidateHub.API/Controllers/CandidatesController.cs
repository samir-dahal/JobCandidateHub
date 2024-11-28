using JobCandidateHub.API.Contracts.Requests;
using JobCandidateHub.API.Contracts.Responses;
using JobCandidateHub.API.DataAccess.Services;
using JobCandidateHub.API.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace JobCandidateHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : BaseApiController
    {
        private readonly ICandidateService _candidateService;
        public CandidatesController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpPost]
        public async Task<IActionResult> CandidateSignup(CandidateRequest request)
        {
            try
            {
                var (valid, message) = request.IsValid();
                if (!valid)
                {
                    return this.CreateApiResult(success: false, message);
                }
                var result = await _candidateService.AddOrUpdateCandidateAsync(request.ToCandidateEntity());
                return this.CreateApiResult(success: true, "Candidate signup successfull", new CandidateResponse
                {
                    CandidateId = result.CandidateId,
                    Email = result.Email,
                });
            }
            catch(Exception ex)
            {
                return this.CreateApiResult(success: false, "Oops! something went wrong. Please try again later.");
            }
        }
    }
}
