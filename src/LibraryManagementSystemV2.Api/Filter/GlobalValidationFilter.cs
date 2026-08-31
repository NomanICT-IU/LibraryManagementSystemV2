public class GlobalValidationFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(
        ActionExecutingContext context,
        ActionExecutionDelegate next)
    {
        foreach (var argument in context.ActionArguments.Values)
        {
            if (argument == null)
                continue;

            var validatorType = typeof(IValidator<>)
                .MakeGenericType(argument.GetType());

            var validator = context.HttpContext.RequestServices
                .GetService(validatorType);

            if (validator == null)
                continue;

            var validationResult = await ((IValidator)validator)
                .ValidateAsync(
                    new ValidationContext<object>(argument),
                    context.HttpContext.RequestAborted);

            if (!validationResult.IsValid)
            {
                var response = new ApiResponse<object>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "Validation failed.",
                    Data = validationResult.Errors.Select(x => new
                    {
                        Field = x.PropertyName,
                        Message = x.ErrorMessage
                    })
                };

                context.Result = new BadRequestObjectResult(response);

                return;
            }
        }

        await next();
    }
}