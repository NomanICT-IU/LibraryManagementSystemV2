using Lms.Mvc.Models;

namespace Lms.Mvc.Services;

public interface IBookService
{
    public Task<ApiResponse<IEnumerable<BookDetailModel>>> SearchBookRecordAsync(string searchBy, string searchText, CancellationToken cancellationToken);
    public Task<ApiResponse<BookModel>> CreateBookAsync(BookModel bookModel, CancellationToken cancellationToken);
    public Task<ApiResponse<BookListResponseModel>> GetBooksync(string searchText, int pageNumber, int pageSize, CancellationToken cancellationToken);

}

public class BookService : IBookService
{
    private readonly HttpClient _httpClient;
    public BookService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("LMSApi");
    }

    public async Task<ApiResponse<BookModel>> CreateBookAsync(
    BookModel bookModel,
    CancellationToken cancellationToken)
    {
        const string endpoint = "api/Book/create-book";

        var response = await _httpClient.PostAsJsonAsync(
            endpoint,
            bookModel,
            cancellationToken);

        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<ApiResponse<BookModel>>(
            cancellationToken);

        return result!;
    }

    public async Task<ApiResponse<BookListResponseModel>> GetBooksync(string searchText, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var endpoint = $"api/Book/get-book-list" +
                       $"?searchText={Uri.EscapeDataString(searchText)}" +
                       $"&pageNumber={pageNumber}" +
                       $"&pageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<ApiResponse<BookListResponseModel>>(endpoint, cancellationToken);

    }

    public async Task<ApiResponse<IEnumerable<BookDetailModel>>> SearchBookRecordAsync(string searchBy, string searchText, CancellationToken cancellationToken)
    {
        var endpoint =
            $"api/Book/search-book-recod-author-isbn-title" +
            $"?searchBy={Uri.EscapeDataString(searchBy)}" +
            $"&searchResult={Uri.EscapeDataString(searchText)}";

        return await _httpClient.GetFromJsonAsync<ApiResponse<IEnumerable<BookDetailModel>>>(endpoint, cancellationToken);
    }
}