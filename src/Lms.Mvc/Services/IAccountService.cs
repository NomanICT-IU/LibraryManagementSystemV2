using Lms.Mvc.Models;

namespace Lms.Mvc.Services;

public interface IAccountService
{
    Task<ApiResponse<LoginResponse>> GetAccountByIdAsync(LoginUserModel userModel, CancellationToken cancellationToken);
}
public class AccountService : IAccountService
{
    private readonly HttpClient _httpClientFactory;
    public AccountService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory.CreateClient("LMSApi");
    }
    public async Task<ApiResponse<LoginResponse>> GetAccountByIdAsync(LoginUserModel userModel, CancellationToken cancellationToken)
    {
        var endpoint = $"api/Account/login";

        var response = await _httpClientFactory.PostAsJsonAsync(
            endpoint,
            userModel,
            cancellationToken);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<ApiResponse<LoginResponse>>(cancellationToken);

        }

        var errorResponse = await response.Content.ReadFromJsonAsync<ErrorMessageResult>(
            cancellationToken);

        return new ApiResponse<LoginResponse>
        {
            Message = errorResponse?.Message ?? "An unexpected error occurred."

        };
    }
}




