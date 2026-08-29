namespace LibraryManagementSystemV2.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BorrowRecordController : ControllerBase
{
    private readonly IBorrowRecordService _borrowRecordService;

    public BorrowRecordController(IBorrowRecordService borrowRecordService)
    {
        _borrowRecordService = borrowRecordService;
    }

    [HttpPost("create-borrow-record")]
    public async Task<IActionResult> CreateBorrowRecordAsync([FromBody] BorrowRecordDto recordDto, CancellationToken cancellationToken)
    {
        var result = await _borrowRecordService.CreateBorrowRecordAsync(recordDto, cancellationToken);

        return Ok(new ApiResponse<BorrowRecordDetailsDto>(
                  result,
                  "Borrow record created successfully."
                  ));
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
                new ApiResponse<bool>(
                    false,
                    "Book Record not found."
                )
            );
        }

        return Ok(
            new ApiResponse<bool>(
                true,
                "Book Record deleted successfully."
            )
        );
    }

    [HttpGet("get-borrow-record-by-id/{borrowId:int}")]
    public async Task<IActionResult> GetBorrowRecordByIdAsync(int borrowId, CancellationToken cancellationToken)
    {
        var result = await _borrowRecordService.GetBorrowRecordByIdAsync(borrowId, cancellationToken);
        return Ok(new ApiResponse<BorrowRecordDto>(
                  result,
                  "Get Borrow Record successfully."
                  ));

    }

    [HttpPut("update-borrow-record")]
    public async Task<IActionResult> UpdateBorrowRecordAsync([FromBody] BorrowRecordDto recordDto, CancellationToken cancellationToken)
    {
        var result = await _borrowRecordService.UpdateBorrowRecordAsync(recordDto, cancellationToken);

        if (!result)
        {
            return NotFound(
                new ApiResponse<bool>(
                    false,
                    "Borrow Record not Updated."
                )
            );
        }

        return Ok(
            new ApiResponse<bool>(
                true,
                "Borrow Record Updated successfully."
            )
        );
    }
}
