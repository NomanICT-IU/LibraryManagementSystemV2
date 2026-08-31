using Lms.Mvc.Models;

namespace Lms.Mvc.Services;

public interface IBookService
{
    public Task<ApiResponse<IEnumerable<BookDetailModel>>> SearchBookRecordAsync(string searchBy, string searchText, CancellationToken cancellationToken);
}

public class BookService : IBookService
{
    private readonly HttpClient _httpClient;
    public BookService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("LMSApi");
    }

    public async Task<ApiResponse<IEnumerable<BookDetailModel>>> SearchBookRecordAsync(string searchBy, string searchText, CancellationToken cancellationToken)
    {
        var endpoint =
            $"api/Book/search-book-recod" +
            $"?searchBy={Uri.EscapeDataString(searchBy)}" +
            $"&searchResult={Uri.EscapeDataString(searchText)}";

        return await _httpClient.GetFromJsonAsync<ApiResponse<IEnumerable<BookDetailModel>>>(endpoint, cancellationToken);
    }
}