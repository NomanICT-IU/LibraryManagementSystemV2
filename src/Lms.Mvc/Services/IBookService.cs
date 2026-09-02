using Lms.Mvc.Models;

namespace Lms.Mvc.Services;

public interface IBookService
{
    public Task<ApiResponse<IEnumerable<BookDetailModel>>> SearchBookRecordAsync(string searchBy, string searchText, CancellationToken cancellationToken);
    public Task<ApiResponse<BookModel>> CreateBookAsync(BookModel bookModel, CancellationToken cancellationToken);
    public Task<ApiResponse<BookListResponseModel>> GetBooksync(string searchText, int pageNumber, int pageSize, CancellationToken cancellationToken);
    public Task<ApiResponse<BookModel>> GetBookByIdAsync(int bookId, CancellationToken cancellationToken);
    public Task<ApiResponse<bool>> UpdateBookAsync(BookModel bookModel, CancellationToken cancellationToken);
    public Task<ApiResponse<bool>> DeleteBookAsync(int bookId, CancellationToken cancellationToken);
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

    public async Task<ApiResponse<bool>> DeleteBookAsync(int bookId, CancellationToken cancellationToken)
    {
        string endpoint = $"api/Book/delete-book/{bookId}";
        return await _httpClient.DeleteFromJsonAsync<ApiResponse<bool>>(endpoint, cancellationToken);
    }

    public async Task<ApiResponse<BookModel>> GetBookByIdAsync(int bookId, CancellationToken cancellationToken)
    {
        string endpoint = $"api/Book/get-book-by-id/{bookId}";

        return await _httpClient.GetFromJsonAsync<ApiResponse<BookModel>>(endpoint, cancellationToken);

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

    public async Task<ApiResponse<bool>> UpdateBookAsync(BookModel bookModel, CancellationToken cancellationToken)
    {
        var endpoint = "api/Book/update-book";

        var response = await _httpClient.PutAsJsonAsync(
            endpoint,
            bookModel,
            cancellationToken);

        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<ApiResponse<bool>>(
            cancellationToken);

        return result!;


    }
}