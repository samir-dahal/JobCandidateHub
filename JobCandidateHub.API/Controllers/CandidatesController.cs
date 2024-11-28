using JobCandidateHub.API.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;

namespace JobCandidateHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CandidateSignup(CandidateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
