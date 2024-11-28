namespace JobCandidateHub.API.Contracts.Responses
{
    public class BaseResponse<T>
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public T Result { get; set; }
    }
}
