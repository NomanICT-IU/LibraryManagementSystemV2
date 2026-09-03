using Lms.Mvc.Models;

namespace Lms.Mvc.Services;

public interface IBookCopyService
{
    public Task<ApiResponse<BookCopyResponseModel>> GetBookCopyListAsync(
        string searchText,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken);
    public Task<ApiResponse<BookCopyModel>> CreateBookCopiesAsync(BookCopyModel BookCopyModel, CancellationToken cancellationToken);
    public Task<ApiResponse<BookCopyViewModel>> GetBookCopyById(int copyId, CancellationToken cancellationToken);

    public Task<ApiResponse<bool>> UpdateBookCopyAsync(BookCopyViewModel bookCopyViewModel, CancellationToken cancellationToken);
}

public class BookCopyService : IBookCopyService
{
    private readonly HttpClient _httpClient;

    public BookCopyService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("LMSApi");
    }

    public async Task<ApiResponse<BookCopyModel>> CreateBookCopiesAsync(
      BookCopyModel bookCopyModel,
      CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "api/BookCopy/create-book-copy",
            bookCopyModel,
            cancellationToken);

        response.EnsureSuccessStatusCode();

        var result = await response.Content
            .ReadFromJsonAsync<ApiResponse<BookCopyModel>>(
               cancellationToken);

        return result!;
    }

    public async Task<ApiResponse<BookCopyViewModel>> GetBookCopyById(int copyId, CancellationToken cancellationToken)
    {
        var endpoint = $"api/BookCopy/get-book-copy-by-id/{copyId}";

        var result = await _httpClient
            .GetFromJsonAsync<ApiResponse<BookCopyViewModel>>(
                endpoint,
                cancellationToken);

        return result!;
    }

    public async Task<ApiResponse<BookCopyResponseModel>> GetBookCopyListAsync(
        string searchText,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken)
    {
        var endpoint =
            $"api/BookCopy/get-book-copy-list" +
            $"?searchText={Uri.EscapeDataString(searchText ?? string.Empty)}" +
            $"&pageNumber={pageNumber}" +
            $"&pageSize={pageSize}";

        var response =
            await _httpClient.GetFromJsonAsync<ApiResponse<BookCopyResponseModel>>(
                endpoint,
                cancellationToken);

        return response!;
    }

    public async Task<ApiResponse<bool>> UpdateBookCopyAsync(BookCopyViewModel bookCopyViewModel, CancellationToken cancellationToken)
    {
        var endpoint = "api/BookCopy/update-book-copy";

        var response = await _httpClient.PutAsJsonAsync(
            endpoint,
            bookCopyViewModel,
            cancellationToken);

        var result = await response.Content
            .ReadFromJsonAsync<ApiResponse<bool>>(
                cancellationToken);

        return result!;

    }
}