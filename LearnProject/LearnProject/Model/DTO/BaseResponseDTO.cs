namespace LearnProject.Model.DTO
{
    public class BaseResponse
    {
        public int ApiResponseStatusCode { get; set; }
        public string Message { get; set; }  
    }
    public class BaseResponseDTO<T> : BaseResponse
    {
        public int InternalStatusCode { get; set; }
        public T Data { get; set; }
        public string Token { get; set; }
    }
}
