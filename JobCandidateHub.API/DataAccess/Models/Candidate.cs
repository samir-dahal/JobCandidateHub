namespace JobCandidateHub.API.DataAccess.Models
{
    public class Candidate
    {
        public int CandidateId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string Email { get; set; } = null!;
        /// <summary>
        /// Using date time here for accurate time to call the candidate if provided
        /// </summary>
        public DateTime? BestTimeToCall { get; set; }
        public string? LinkedInProfileUrl { get; set; }
        public string? GitHubProfileUrl { get; set; }
        public string Comment { get; set; } = null!;
    }
}
