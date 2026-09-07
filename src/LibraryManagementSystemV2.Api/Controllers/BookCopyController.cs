namespace LibraryManagementSystemV2.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookCopyController(IBookCopyService _bookCopyService) : ControllerBase
{

    [HttpPost("create-book-copy")]
    public async Task<IActionResult> CreateBookAsync([FromBody] BookCopyDto bookCopyDto, CancellationToken cancellationToken)
    {
        var result = await _bookCopyService.CreateBookCopyAsync(bookCopyDto, cancellationToken);

        return Ok(new ApiResponse<BookCopyDto> { Data = result });
    }
    [HttpDelete("delete-book-copy/{copyId:int}")]
    public async Task<IActionResult> DeleteBookCopyAsync(int copyId, CancellationToken cancellationToken)
    {
        var result = await _bookCopyService.DeleteBookCopyAsync(
            copyId,
            cancellationToken);



        return Ok(
            new ApiResponse<bool> { Data = result }
        );
    }


    [HttpGet("get-book-copy-by-id/{copyId:int}")]
    public async Task<IActionResult> GetBookCopyByIdAsync(int copyId, CancellationToken cancellationToken)
    {
        var result = await _bookCopyService.GetBookCopyByIdAsync(copyId, cancellationToken);
        return Ok(new ApiResponse<BookCopyViewDto> { Data = result });

    }

    [HttpPut("update-book-copy/{copyId:int}")]
    public async Task<IActionResult> UpdateBookCopyAsync(int copyId, [FromBody] BookCopyDto bookCopyDto, CancellationToken cancellationToken)
    {
        var result = await _bookCopyService.UpdateBookCopyAsync(copyId, bookCopyDto, cancellationToken);



        return Ok(
            new ApiResponse<bool> { Data = result }
        );
    }

    [HttpGet("get-book-copies/{bookId:int}")]
    public async Task<IActionResult> GetBookCopyListAsync(
    int bookId,
    CancellationToken cancellationToken)
    {
        var result = await _bookCopyService.GetBookCopyListAsync(
            bookId,
            cancellationToken);

        return Ok(new ApiResponse<IEnumerable<BookCopyResponseDto>>
        {
            Data = result
        });
    }
}
