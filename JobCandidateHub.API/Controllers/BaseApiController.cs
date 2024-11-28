using Microsoft.AspNetCore.Mvc;

namespace JobCandidateHub.API.Controllers
{
    public class BaseApiController : ControllerBase
    {
        protected ObjectResult CreateApiResult(bool success, string message = null, object result = null)
        {
            if (!success)
            {
                return BadRequest(new { Success = success, Message = message, Result = result });
            }
            return Ok(new { Success = success, Message = message, Result = result });
        }
    }
}
