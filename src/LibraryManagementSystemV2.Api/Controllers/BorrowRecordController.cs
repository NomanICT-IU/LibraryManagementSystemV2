namespace LibraryManagementSystemV2.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BorrowRecordController(IBorrowRecordService _borrowRecordService) : ControllerBase
{

    [HttpPost("create-borrow-record")]
    public async Task<IActionResult> CreateBorrowRecordAsync([FromBody] BorrowRecordDto recordDto, CancellationToken cancellationToken)
    {
        var result = await _borrowRecordService.CreateBorrowRecordAsync(recordDto, cancellationToken);

        return Ok(new ApiResponse<BorrowRecordDetailsDto> { Data = result });
    }

    [HttpDelete("delete-borrow-record/{borrowId:int}")]
    public async Task<IActionResult> DeleteBorrowRecordAsync(int borrowId, CancellationToken cancellationToken)
    {
        var result = await _borrowRecordService.DeleteBorrowRecordAsync(
            borrowId,
            cancellationToken);

        if (!result)
        {
            return NotFound(
                new ApiResponse<bool> { Data = result }
            );
        }

        return Ok(
            new ApiResponse<bool> { Data = result }
        );
    }

    [HttpGet("get-borrow-record-by-id/{borrowId:int}")]
    public async Task<IActionResult> GetBorrowRecordByIdAsync(int borrowId, CancellationToken cancellationToken)
    {
        var result = await _borrowRecordService.GetBorrowRecordByIdAsync(borrowId, cancellationToken);
        return Ok(new ApiResponse<BorrowRecordDto> { Data = result });

    }

    [HttpPut("update-borrow-record")]
    public async Task<IActionResult> UpdateBorrowRecordAsync([FromBody] BorrowRecordDto recordDto, CancellationToken cancellationToken)
    {
        var result = await _borrowRecordService.UpdateBorrowRecordAsync(recordDto, cancellationToken);


        return Ok(
            new ApiResponse<bool> { Data = result }
        );
    }

    [HttpGet("search-borrowed-book")]
    public async Task<IActionResult> SearchBorrowedBookAsync([FromQuery] string searchBy, [FromQuery] string searchText, CancellationToken cancellationToken)

    {
        var result = await _borrowRecordService.SearchBorrowedBookAsync(searchBy, searchText, cancellationToken);
        return Ok(new ApiResponse<IEnumerable<BorrowBookSearchResultDto>> { Data = result });

    }

    [HttpPut("return-book")]
    public async Task<IActionResult> ReturnBorrowedBookAsync([FromQuery] int borrowId, CancellationToken cancellationToken)
    {
        var result = await _borrowRecordService.ReturnBorrowedBookAsync(borrowId, cancellationToken);
        return Ok(new ApiResponse<ReturnedBookDto> { Data = result });
    }
}
