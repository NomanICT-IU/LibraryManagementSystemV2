using Lms.Mvc.Models;

namespace Lms.Mvc.Services;

public interface IAccountService
{
    Task<ApiResponse<AccountModel>> GetAccountByIdAsync(LoginUserModel userModel, CancellationToken cancellationToken);
}
public class AccountService : IAccountService
{
    private readonly HttpClient _httpClientFactory;
    public AccountService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory.CreateClient("LMSApi");
    }
    public async Task<ApiResponse<AccountModel>> GetAccountByIdAsync(LoginUserModel userModel, CancellationToken cancellationToken)
    {
        var endpoint =
            $"api/Account?Identity={Uri.EscapeDataString(userModel.Identifier)}" +
            $"&Password={Uri.EscapeDataString(userModel.Password)}";

        var response = await _httpClientFactory.GetAsync(
            endpoint,
            cancellationToken);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<ApiResponse<AccountModel>>(cancellationToken);

        }

        var errorResponse = await response.Content.ReadFromJsonAsync<ErrorMessageResult>(
            cancellationToken);

        return new ApiResponse<AccountModel>
        {
            Message = errorResponse?.Message ?? "An unexpected error occurred."

        };
    }
}




