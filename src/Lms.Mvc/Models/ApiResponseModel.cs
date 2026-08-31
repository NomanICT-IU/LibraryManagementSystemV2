namespace Lms.Mvc.Models
{
    public class ApiResponse<T> : ErrorMessageResult
    {

        public T Data { get; set; }
        public int StatusCode { get; set; }
    }

    public class ErrorMessageResult
    {
        private string _errorMessage;

        public bool IsError { get; private set; }

        public string Message
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                IsError = !string.IsNullOrWhiteSpace(value);
            }
        }
    }
}
