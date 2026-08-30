namespace LibraryManagementSystemV2.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookCopyController(IBookCopyService _bookCopyService) : ControllerBase
{

    [HttpPost("create-book-copy")]
    public async Task<IActionResult> CreateBookAsync([FromBody] BookCopyDto bookCopyDto, CancellationToken cancellationToken)
    {
        var result = await _bookCopyService.CreateBookCopyAsync(bookCopyDto, cancellationToken);

        return Ok(new ApiResponse<BookCopyDto>(
                  result,
                  "Book Copy created successfully."
                  ));
    }
    [HttpDelete("delete-book-copy/{copyId:int}")]
    public async Task<IActionResult> DeleteBookCopyAsync(int copyId, CancellationToken cancellationToken)
    {
        var result = await _bookCopyService.DeleteBookCopyAsync(
            copyId,
            cancellationToken);

        if (!result)
        {
            return NotFound(
                new ApiResponse<bool>(
                    false,
                    "Book copy not found."
                )
            );
        }

        return Ok(
            new ApiResponse<bool>(
                true,
                "Book copy deleted successfully."
            )
        );
    }


    [HttpGet("get-book-copy-by-id/{copyId:int}")]
    public async Task<IActionResult> GetBookCopyByIdAsync(int copyId, CancellationToken cancellationToken)
    {
        var result = await _bookCopyService.GetBookCopyByIdAsync(copyId, cancellationToken);
        return Ok(new ApiResponse<BookCopyDto>(
                  result,
                  "Get Book copy successfully."
                  ));

    }

    [HttpPut("update-book-copy")]
    public async Task<IActionResult> UpdateBookCopyAsync([FromBody] BookCopyDto bookCopyDto, CancellationToken cancellationToken)
    {
        var result = await _bookCopyService.UpdateBookCopyAsync(bookCopyDto, cancellationToken);

        if (!result)
        {
            return NotFound(
                new ApiResponse<bool>(
                    false,
                    "Book copy not Updated."
                )
            );
        }

        return Ok(
            new ApiResponse<bool>(
                true,
                "Book Copy Updated successfully."
            )
        );
    }
}
