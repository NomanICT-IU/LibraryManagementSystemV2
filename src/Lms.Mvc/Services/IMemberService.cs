using Lms.Mvc.Models;

namespace Lms.Mvc.Services;

public interface IMemberService
{
    public Task<ApiResponse<MemberListModel>> GetMemberList(string searchText, int pageNumber, int pageSize, CancellationToken cancellationToken);
    public Task<ApiResponse<MemberModel>> CreateMemberAsync(MemberModel memberModel, CancellationToken cancellationToken);
    public Task<ApiResponse<MemberModel>> GetMemberByIdAsync(int memberId, CancellationToken cancellationToken);
    public Task<ApiResponse<bool>> UpdateMemberAsync(MemberModel memberModel, CancellationToken cancellationToken);
}

public class MemberService : IMemberService
{
    private readonly HttpClient _httpClientFactory;

    public MemberService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory.CreateClient("LMSApi");
    }
    public async Task<ApiResponse<MemberListModel>> GetMemberList(string searchText, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {

        var endpoint =
        $"api/Member/get-member-list-Name-Id-phone-email-address" +
        $"?searchText={Uri.EscapeDataString(searchText ?? string.Empty)}" +
        $"&pageNumber={pageNumber}" +
        $"&pageSize={pageSize}";

        var response = await _httpClientFactory
            .GetFromJsonAsync<ApiResponse<MemberListModel>>(
                endpoint,
                cancellationToken);

        return response!;
    }
    public async Task<ApiResponse<MemberModel>> CreateMemberAsync(
     MemberModel memberModel,
     CancellationToken cancellationToken)
    {
        var endpoint = "api/Member/create-member";

        var response = await _httpClientFactory.PostAsJsonAsync(
            endpoint,
            memberModel,
            cancellationToken);

        response.EnsureSuccessStatusCode();

        var result = await response.Content
            .ReadFromJsonAsync<ApiResponse<MemberModel>>(
                cancellationToken);

        return result!;
    }

    public async Task<ApiResponse<MemberModel>> GetMemberByIdAsync(
     int memberId,
     CancellationToken cancellationToken)
    {
        var endpoint = $"api/Member/get-member-by-id/{memberId}";

        var result = await _httpClientFactory
            .GetFromJsonAsync<ApiResponse<MemberModel>>(
                endpoint,
                cancellationToken);

        return result!;
    }

    public async Task<ApiResponse<bool>> UpdateMemberAsync(
       MemberModel memberModel,
       CancellationToken cancellationToken)
    {
        var endpoint = "api/Member/update-member";

        var response = await _httpClientFactory.PutAsJsonAsync(
            endpoint,
            memberModel,
            cancellationToken);

        var result = await response.Content
            .ReadFromJsonAsync<ApiResponse<bool>>(
                cancellationToken);

        return result!;
    }
}

