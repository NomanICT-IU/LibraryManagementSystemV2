using Lms.Mvc.Models;
using Lms.Mvc.Models.ViewModels;

namespace Lms.Mvc.Services;

public interface IMemberService
{
    public Task<ApiResponse<MemberListModel>> GetMemberList(string searchText, int pageNumber, int pageSize, CancellationToken cancellationToken);
    public Task<ApiResponse<MemberModel>> CreateMemberAsync(MemberModel memberModel, CancellationToken cancellationToken);
    public Task<ApiResponse<MemberModel>> GetMemberByIdAsync(int memberId, CancellationToken cancellationToken);
    public Task<ApiResponse<bool>> UpdateMemberAsync(MemberModel memberModel, CancellationToken cancellationToken);
    public Task<ApiResponse<bool>> DeleteMemberAsync(int memberId, CancellationToken cancellationToken);
    public Task<ApiResponse<MemberInformationModel>> FindMemberAsync(string searchText, CancellationToken cancellationToken);
    public Task<ApiResponse<MemberDetailsViewModel>> GetMemberDetailsAsync(string searchBy, string searchText, CancellationToken cancellationToken);
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

    public async Task<ApiResponse<bool>> DeleteMemberAsync(int memberId, CancellationToken cancellationToken)
    {
        var endpoint = $"api/Member/delete-member/{memberId}";
        return await _httpClientFactory.DeleteFromJsonAsync<ApiResponse<bool>>(endpoint, cancellationToken);
    }

    public async Task<ApiResponse<MemberInformationModel>> FindMemberAsync(string searchText, CancellationToken cancellationToken)
    {
        var endpoint = $"api/Member/find-member-by-member-id-or-member-phone" +
            $"?searchText={searchText}";

        return await _httpClientFactory.GetFromJsonAsync<ApiResponse<MemberInformationModel>>(endpoint, cancellationToken);
    }


    public async Task<ApiResponse<MemberDetailsViewModel>> GetMemberDetailsAsync(
        string searchBy,
        string searchText,
        CancellationToken cancellationToken = default)
    {
        var endpoint =
            $"api/Member/get-member-details" +
            $"?searchBy={Uri.EscapeDataString(searchBy ?? string.Empty)}" +
            $"&searchText={Uri.EscapeDataString(searchText ?? string.Empty)}";

        var response = await _httpClientFactory
            .GetFromJsonAsync<ApiResponse<MemberDetailsViewModel>>(
                endpoint,
                cancellationToken);

        return response ?? new ApiResponse<MemberDetailsViewModel>();
    }


}

