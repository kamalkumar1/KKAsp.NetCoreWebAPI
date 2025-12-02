namespace LearnProject.Model
{
    public class ResultBaseModel<T>
    {
        public int Statuscode { get; set; }
        public string? Message { get; set; }
        public BaseResult<T>? BaseResult { get; set; }
    }

    public class BaseResult<T>
    {
        public T Data { get; set; }
    }
    public class BaseModel
    {
        public int Statuscode { get; set; }
        public string? Message { get; set; }
        public Result? Result { get; set; }
    }
    public class Result
    {
       
        public object? Data { get; set; }

    }
}
