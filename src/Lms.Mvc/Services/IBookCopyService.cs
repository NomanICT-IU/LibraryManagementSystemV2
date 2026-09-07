using Lms.Mvc.Models;

namespace Lms.Mvc.Services;

public interface IBookCopyService
{
    public Task<ApiResponse<IEnumerable<BookCopyResponseModel>>> GetBookCopyListAsync(int bookId,
        CancellationToken cancellationToken);
    public Task<ApiResponse<BookCopyModel>> CreateBookCopiesAsync(BookCopyModel BookCopyModel, CancellationToken cancellationToken);
    public Task<ApiResponse<BookCopyModel>> GetBookCopyById(int copyId, CancellationToken cancellationToken);

    public Task<ApiResponse<bool>> UpdateBookCopyAsync(int copyId, BookCopyModel bookCopyViewModel, CancellationToken cancellationToken);
    public Task<ApiResponse<bool>> DeleteBookCopyAsync(int copyId, CancellationToken cancellationToken);
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

    public async Task<ApiResponse<bool>> DeleteBookCopyAsync(int copyId, CancellationToken cancellationToken)
    {
        var endpoint = $"api/BookCopy/delete-book-copy/{copyId}";

        var response = await _httpClient.DeleteAsync(
            endpoint,
            cancellationToken);
        var result = await response.Content
            .ReadFromJsonAsync<ApiResponse<bool>>(
                cancellationToken);
        return result!;
    }

    public async Task<ApiResponse<BookCopyModel>> GetBookCopyById(int copyId, CancellationToken cancellationToken)
    {
        var endpoint = $"api/BookCopy/get-book-copy-by-id/{copyId}";

        var result = await _httpClient
            .GetFromJsonAsync<ApiResponse<BookCopyModel>>(
                endpoint,
                cancellationToken);

        return result!;
    }

    public async Task<ApiResponse<IEnumerable<BookCopyResponseModel>>> GetBookCopyListAsync(
         int bookId,
        CancellationToken cancellationToken)
    {
        var endpoint =
            $"api/BookCopy/get-book-copies/{bookId}";

        var response =
            await _httpClient.GetFromJsonAsync<ApiResponse<IEnumerable<BookCopyResponseModel>>>(
                endpoint,
                cancellationToken);

        return response!;
    }

    public async Task<ApiResponse<bool>> UpdateBookCopyAsync(int copyId, BookCopyModel bookCopyViewModel, CancellationToken cancellationToken)
    {
        var endpoint = $"api/BookCopy/update-book-copy/{copyId}";

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