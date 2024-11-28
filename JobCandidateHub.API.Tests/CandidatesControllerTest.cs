
using FluentAssertions;
using JobCandidateHub.API.Contracts.Requests;
using JobCandidateHub.API.Contracts.Responses;
using System.Net.Http.Json;
using System.Text.Json;

namespace JobCandidateHub.API.Tests
{
    public class CandidatesControllerTest : IntegrationTest
    {
        private readonly JsonSerializerOptions _jsonOptions;
        public CandidatesControllerTest()
        {
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
        }
        [Fact]
        public async Task Should_Create_New_Candidate_If_Not_Exists()
        {
            // Arrange
            var candidateRequest = new CandidateRequest
            {
                FirstName = "New",
                LastName = "Candidate",
                Email = "new.candidate@example.com",
                PhoneNumber = "9876543210",
                Comment = "Adding a new candidate.",
                GitHubProfileUrl = "https://github.com/new-candidate",
                LinkedInProfileUrl = "https://www.linkedin.com/in/new-candidate/",
            };

            // Act
            var response = await Client.PostAsJsonAsync("/api/candidates", candidateRequest);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var returnedResponse = JsonSerializer.Deserialize<BaseResponse<CandidateResponse>>(await response.Content.ReadAsStringAsync(), _jsonOptions);
            returnedResponse!.Result.Email.Should().Be("new.candidate@example.com");
            returnedResponse.Result.FirstName.Should().Be("New");
            returnedResponse.Result.LastName.Should().Be("Candidate");
        }

        [Fact]
        public async Task Should_Return_BadRequest_For_Invalid_Email()
        {
            // Arrange
            var candidateRequest = new CandidateRequest
            {
                FirstName = "Samir",
                LastName = "Dahal",
                Email = "invalid-email", //here invalid email is set
                PhoneNumber = "9817079174",
                Comment = "Hi there!",
                GitHubProfileUrl = "https://github.com/samir-dahal",
                LinkedInProfileUrl = "https://www.linkedin.com/in/samir-dahal/",
            };

            // Act
            var response = await Client.PostAsJsonAsync("/api/candidates", candidateRequest);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);

            var errorResponse = await response.Content.ReadAsStringAsync();
            errorResponse.Should().Contain("Please provide a valid email address");
        }

        [Fact]
        public async Task Should_Update_Existing_Candidate()
        {
            // Arrange
            var initialRequest = new CandidateRequest
            {
                FirstName = "Existing",
                LastName = "Candidate",
                Email = "existing.candidate@example.com",
                PhoneNumber = "9876543210",
                Comment = "Initial comment.",
                GitHubProfileUrl = "https://github.com/existing-candidate",
                LinkedInProfileUrl = "https://www.linkedin.com/in/existing-candidate/",
            };
            await Client.PostAsJsonAsync("/api/candidates", initialRequest);

            var updatedRequest = new CandidateRequest
            {
                FirstName = "Updated",
                LastName = "Candidate",
                Email = "existing.candidate@example.com",
                PhoneNumber = "1234567890",
                Comment = "Updated comment.",
                GitHubProfileUrl = "https://github.com/updated-candidate",
                LinkedInProfileUrl = "https://www.linkedin.com/in/updated-candidate/",
            };

            // Act
            var response = await Client.PostAsJsonAsync("/api/candidates", updatedRequest);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var returnedResponse = JsonSerializer.Deserialize<BaseResponse<CandidateResponse>>(await response.Content.ReadAsStringAsync(), _jsonOptions);
            returnedResponse!.Result.FirstName.Should().Be("Updated");
            returnedResponse.Result.LastName.Should().Be("Candidate");
        }
    }
}