namespace Application.Services.DTOs
{
    public class ServiceResponseApi<T>
    {
         public int StatusCode { get; set; }

        public bool Success { get; set; }

        public T? Data { get; set; }

        public List<string> Errors { get; set; }
        public ServiceResponseApi()
        {
            Success = true;
            Errors = new List<string>();
        }
        public ServiceResponseApi(int statusCode, T data)
        {
            StatusCode = statusCode;
            Success = true;
            Data = data;
            Errors = new List<string>();
        }
        public ServiceResponseApi(int statusCode, List<string> errors)
        {
            StatusCode = statusCode;
            Success = false;
            Errors = errors;
        }
        public ServiceResponseApi(int statusCode, string error)
        {
            StatusCode = statusCode;
            Success = false;
            Errors = new List<string> { error };
        }
    }
    
}
