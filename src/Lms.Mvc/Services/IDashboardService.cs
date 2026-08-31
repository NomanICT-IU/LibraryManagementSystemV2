using Lms.Mvc.Models;

namespace Lms.Mvc.Services;

public interface IDashboardService
{
    public Task<ApiResponse<DashBoardModel>> GetDashBoardInformation(CancellationToken cancellationToken);
}

public class DashboardService : IDashboardService
{
    private readonly HttpClient _httpClient;
    public DashboardService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("LMSApi");
    }


    public async Task<ApiResponse<DashBoardModel>> GetDashBoardInformation(CancellationToken cancellationToken)
    {
        const string endpoint = "api/DashBoards/get-dashboard-information";
        var result = await _httpClient.GetFromJsonAsync<ApiResponse<DashBoardModel>>(
            endpoint,
            cancellationToken);
        return result;
    }


}
