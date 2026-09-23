using LibraryManagementSystemV2.Shared.Constants;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LibraryManagementSystemV2.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BookController(IBookService _bookService) : ControllerBase
{
    [HttpPost("create-book")]
    [Authorize(Policy = Permissions.Book.Create)]
    public async Task<IActionResult> CreateBookAsync([FromBody] BookDto bookDto, CancellationToken cancellationToken)
    {
        var result = await _bookService.CreateBookAsync(bookDto, cancellationToken);

        return Ok(new ApiResponse<BookDto>
        {
            Data = result,
        });
    }
    [HttpDelete("delete-book/{bookId:int}")]
    [Authorize(Policy = Permissions.Book.Delete)]
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
    [Authorize(Policy = Permissions.Book.Read)]
    public async Task<IActionResult> GetBookByIdAsync(int bookId, CancellationToken cancellationToken)
    {
        var result = await _bookService.GetBookByIdAsync(bookId, cancellationToken);
        return Ok(new ApiResponse<BookDto>
        {
            Data = result
        });

    }
    [HttpPut("update-book")]
    [Authorize(Policy = Permissions.Book.Update)]
    public async Task<IActionResult> UpdateBookAsync([FromBody] BookDto bookDto, CancellationToken cancellationToken)
    {
        var result = await _bookService.UpdateBookAsync(bookDto, cancellationToken);
        return Ok(
            new ApiResponse<bool> { Data = result }
        );
    }

    [HttpGet("search-book-recod-author-isbn-title")]
    [Authorize(Policy = Permissions.Book.Read)]
    public async Task<IActionResult> SearchBookRecordAsync(string searchBy = "", string searchText = "", int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var result = await _bookService.SearchBookRecordAsync(searchBy, searchText, pageNumber, pageSize, cancellationToken);

        return Ok(new ApiResponse<BookCopyDetailsReponseDto> { Data = result });
    }

    [HttpGet("get-book-copy-detail-id/{copyId:int}")]
    public async Task<IActionResult> GetBookCopyDetailsAsync(int copyId, CancellationToken cancellationToken)
    {
        var result = await _bookService.GetBookCopyDetailsAsync(copyId, cancellationToken);

        return Ok(new ApiResponse<BookDetailsDto> { Data = result }); ;
    }

    [HttpGet("get-book-detail")]
    [Authorize(Policy = Permissions.Book.All)]
    public async Task<IActionResult> GetBookDetailsAsync(string searchBy = "", string searchResult = "",
    CancellationToken cancellationToken = default)
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
    [Authorize(Policy = Permissions.Book.All)]
    public async Task<IActionResult> GetBookListAsync(string searchText, int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
        var result = await _bookService.GetBookListAsync(searchText, pageNumber, pageSize, cancellationToken);
        return Ok(new ApiResponse<BookListResponseDto>
        {
            Data = result,

        });
    }

}
