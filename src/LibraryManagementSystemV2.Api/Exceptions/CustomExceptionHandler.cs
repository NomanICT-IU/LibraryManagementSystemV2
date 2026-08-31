namespace LibraryManagementSystemV2.Api.Exceptions
{
    public class CustomExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionHandler> _logger;

        public CustomExceptionHandler(
            RequestDelegate next,
            ILogger<CustomExceptionHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Unhandled exception occurred. Path: {Path}",
                    context.Request.Path);

                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(
         HttpContext context,
         Exception exception)
        {
            context.Response.ContentType = "application/json";

            var statusCode = exception switch
            {
                InvalidException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                BadRequestException => StatusCodes.Status400BadRequest,
                UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError
            };

            context.Response.StatusCode = statusCode;

            var response = new ApiResponse<object>
            {
                StatusCode = statusCode,
                Message = exception switch
                {
                    NotFoundException => exception.Message,
                    BadRequestException => exception.Message,
                    UnauthorizedAccessException => exception.Message,
                    _ => "An unexpected error occurred."
                }
            };

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
