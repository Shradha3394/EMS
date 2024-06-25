namespace UserManagement.Common.Models
{
    public class BaseResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }

        public BaseResponse()
        {
        }

        public BaseResponse(T data)
        {
            Success = true;
            Data = data;
        }

        public BaseResponse(string errorMessage, string errorCode = null)
        {
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
        }
    }
}
