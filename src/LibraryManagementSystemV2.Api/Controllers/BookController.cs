namespace LibraryManagementSystemV2.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpPost("create-book")]
    public async Task<IActionResult> CreateBookAsync([FromBody] BookDto bookDto, CancellationToken cancellationToken)
    {
        var result = await _bookService.CreateBookAsync(bookDto, cancellationToken);

        return Ok(new ApiResponse<BookDto>(
                  result,
                  "Book created successfully."
                  ));
    }
    [HttpDelete("delete-book/{bookId:int}")]
    public async Task<IActionResult> DeleteBookAsync(int bookId, CancellationToken cancellationToken)
    {
        var result = await _bookService.DeleteBookAsync(
            bookId,
            cancellationToken);

        if (!result)
        {
            return NotFound(
                new ApiResponse<bool>(
                    false,
                    "Book not found."
                )
            );
        }

        return Ok(
            new ApiResponse<bool>(
                true,
                "Book deleted successfully."
            )
        );
    }


    [HttpGet("get-book-by-id/{bookId:int}")]

    public async Task<IActionResult> GetBookByIdAsync(int bookId, CancellationToken cancellationToken)
    {
        var result = await _bookService.GetBookByIdAsync(bookId, cancellationToken);
        return Ok(new ApiResponse<BookDto>(
                  result,
                  "Get Book successfully."
                  ));

    }
    [HttpPut("update-book")]
    public async Task<IActionResult> UpdateBookAsync([FromBody] BookDto bookDto, CancellationToken cancellationToken)
    {
        var result = await _bookService.UpdateBookAsync(bookDto, cancellationToken);

        if (!result)
        {
            return NotFound(
                new ApiResponse<bool>(
                    false,
                    "Book not Updated."
                )
            );
        }

        return Ok(
            new ApiResponse<bool>(
                true,
                "Book Updated successfully."
            )
        );
    }

    [HttpGet("search-book-recod")]
    public async Task<IActionResult> SearchBookRecord([FromQuery] string searchBy,
        [FromQuery] string searchResult,
        CancellationToken cancellationToken)
    {
        var result = await _bookService.SearchBookRecordAsync(searchBy, searchResult, cancellationToken);

        return Ok(new ApiResponse<IEnumerable<SearchBookRecordDto>> { Data = result });

    }

    [HttpGet("get-book-copy-details/{copyId:int}")]
    public async Task<IActionResult> GetBookCopyDetailsAsync(int copyId, CancellationToken cancellationToken)
    {
        var result = await _bookService.GetBookCopyDetailsAsync(copyId, cancellationToken);

        return Ok(new ApiResponse<BookDetailsDto> { Data = result });
    }

}
