using Lms.Mvc.Models;

namespace Lms.Mvc.Services;

public interface IDashboardService
{
    public Task<ApiResponse<DashBoardModel>> GetDashBoardInformation(int pageNumber, int pageSize, CancellationToken cancellationToken);
}

public class DashboardService : IDashboardService
{
    private readonly HttpClient _httpClient;
    public DashboardService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("LMSApi");
    }


    public async Task<ApiResponse<DashBoardModel>> GetDashBoardInformation(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        string endpoint = $"api/DashBoards/get-dashboard-information" +
                               $"?pageNumber={pageNumber}" +
                               $"&pageSize={pageSize}";
        var result = await _httpClient.GetFromJsonAsync<ApiResponse<DashBoardModel>>(
            endpoint,
            cancellationToken);
        return result;
    }


}
