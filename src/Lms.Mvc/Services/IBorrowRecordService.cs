using Lms.Mvc.Models;
using Lms.Mvc.Models.ViewModels;

namespace Lms.Mvc.Services;

public interface IBorrowRecordService
{
    public Task<ApiResponse<bool>> CreateBorrowRecordAsync(IssueInformationModel model, CancellationToken cancellationToken);
    public Task<ApiResponse<IEnumerable<BorrowBookSearchResultModel>>> SearchBorrowedBookAsync(string searchBy, string searchText,
    CancellationToken cancellationToken);

    public Task<ApiResponse<bool>> ReturnBorrowedBookAsync(int borrowId, CancellationToken cancellationToken);
}

public class BorrowRecordService : IBorrowRecordService
{
    private readonly HttpClient httpClient;

    public BorrowRecordService(IHttpClientFactory httpClient)
    {
        this.httpClient = httpClient.CreateClient("LMSApi");
    }
    public async Task<ApiResponse<bool>> CreateBorrowRecordAsync(
     IssueInformationModel model,
     CancellationToken cancellationToken)
    {
        var endpoint = "api/BorrowRecord/create-borrow-record";

        var response = await httpClient.PostAsJsonAsync(
            endpoint,
            model,
            cancellationToken);

        response.EnsureSuccessStatusCode();

        var result = await response.Content
            .ReadFromJsonAsync<ApiResponse<bool>>(cancellationToken);

        return result!;
    }

    public async Task<ApiResponse<bool>> ReturnBorrowedBookAsync(int borrowId, CancellationToken cancellationToken)
    {
        var endpoint = $"api/BorrowRecord/return-book/{borrowId}";

        var response = await httpClient.PutAsync(
            endpoint,
            content: null,
            cancellationToken);

        response.EnsureSuccessStatusCode();

        var result = await response.Content
            .ReadFromJsonAsync<ApiResponse<bool>>(cancellationToken);

        return result!;
    }

    public async Task<ApiResponse<IEnumerable<BorrowBookSearchResultModel>>>
     SearchBorrowedBookAsync(
         string searchBy,
         string searchText,
         CancellationToken cancellationToken)
    {
        var endpoint = $"api/BorrowRecord/search-borrowed-book" +
                       $"?searchBy={Uri.EscapeDataString(searchBy)}" +
                       $"&searchText={Uri.EscapeDataString(searchText)}";

        var response = await httpClient.GetFromJsonAsync<
            ApiResponse<IEnumerable<BorrowBookSearchResultModel>>
        >(endpoint, cancellationToken);

        return response ?? new ApiResponse<IEnumerable<BorrowBookSearchResultModel>>();

    }

}