using System;
using System.Text.RegularExpressions;

namespace JobCandidateHub.API.Contracts.Requests
{
    public class CandidateRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? BestTimeToCall { get; set; }
        public string LinkedInProfileUrl { get; set; }
        public string GitHubProfileUrl { get; set; }
        public string Comment { get; set; }
        public (bool valid, string message) IsValid()
        {
            if (string.IsNullOrWhiteSpace(FirstName))
            {
                return (false, "First Name is required");
            }
            if (string.IsNullOrWhiteSpace(LastName))
            {
                return (false, "Last Name is required");
            }
            if (string.IsNullOrWhiteSpace(Email))
            {
                return (false, "Email is required");
            }
            if (string.IsNullOrWhiteSpace(Comment))
            {
                return (false, "Your comment is required.");
            }
            if (!IsValidEmail(Email))
            {
                return (false, "Please provide a valid email address");
            }
            return (true, string.Empty);
        }
        //for now i just used it here, we could also use other fluent validation libary.
        private bool IsValidEmail(string email)
        {
            // Return true if email is in valid e-mail format.
            return Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
    }
}
