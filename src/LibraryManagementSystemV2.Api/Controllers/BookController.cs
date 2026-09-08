namespace LibraryManagementSystemV2.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController(IBookService _bookService) : ControllerBase
{
    [HttpPost("create-book")]
    public async Task<IActionResult> CreateBookAsync([FromBody] BookDto bookDto, CancellationToken cancellationToken)
    {
        var result = await _bookService.CreateBookAsync(bookDto, cancellationToken);

        return Ok(new ApiResponse<BookDto>
        {
            Data = result,
        });
    }
    [HttpDelete("delete-book/{bookId:int}")]
    public async Task<IActionResult> DeleteBookAsync(int bookId, CancellationToken cancellationToken)
    {
        var result = await _bookService.DeleteBookAsync(
            bookId,
            cancellationToken);

        return Ok(
            new ApiResponse<bool> { Data = result }
        );
    }


    [HttpGet("get-book-by-id/{bookId:int}")]

    public async Task<IActionResult> GetBookByIdAsync(int bookId, CancellationToken cancellationToken)
    {
        var result = await _bookService.GetBookByIdAsync(bookId, cancellationToken);
        return Ok(new ApiResponse<BookDto>
        {
            Data = result
        });

    }
    [HttpPut("update-book")]
    public async Task<IActionResult> UpdateBookAsync([FromBody] BookDto bookDto, CancellationToken cancellationToken)
    {
        var result = await _bookService.UpdateBookAsync(bookDto, cancellationToken);
        return Ok(
            new ApiResponse<bool> { Data = result }
        );
    }

    [HttpGet("search-book-recod-author-isbn-title")]
    public async Task<IActionResult> SearchBookRecord([FromQuery] string searchBy,
        [FromQuery] string searchResult,
        CancellationToken cancellationToken)
    {
        var result = await _bookService.SearchBookRecordAsync(searchBy, searchResult, cancellationToken);

        return Ok(new ApiResponse<IEnumerable<BookCopyDetailsDto>> { Data = result });
    }

    [HttpGet("get-book-copy-detail-id/{copyId:int}")]
    public async Task<IActionResult> GetBookCopyDetailsAsync(int copyId, CancellationToken cancellationToken)
    {
        var result = await _bookService.GetBookCopyDetailsAsync(copyId, cancellationToken);

        return Ok(new ApiResponse<BookDetailsDto> { Data = result }); ;
    }

    [HttpGet("get-book-detail-author-isbn-title")]
    public async Task<IActionResult> GetBookDetailsAsync(
    [FromQuery] string searchBy,
    [FromQuery] string searchResult,
    CancellationToken cancellationToken)
    {
        var result = await _bookService.GetBookDetailsAsync(
            searchBy,
            searchResult,
            cancellationToken);

        return Ok(new ApiResponse<BookDetailsResponseDto>
        {
            Data = result
        });
    }
    [HttpGet("get-book-list")]
    public async Task<IActionResult> GetBookListAsync(string searchText, int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var result = await _bookService.GetBookListAsync(searchText, pageNumber, pageSize, cancellationToken);
        return Ok(new ApiResponse<BookListResponseDto>
        {
            Data = result,

        });
    }

}
