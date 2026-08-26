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

        return Ok(new ApiResponse<BorrowRecordDto>(
                  result,
                  "Borrow record created successfully."
                  ));
    }

    //[HttpDelete("delete-member/{memberId:int}")]
    //public async Task<IActionResult> DeleteMemberAsync(int memberId, CancellationToken cancellationToken)
    //{
    //    var result = await _memberService.DeleteMemberAsync(
    //        memberId,
    //        cancellationToken);

    //    if (!result)
    //    {
    //        return NotFound(
    //            new ApiResponse<bool>(
    //                false,
    //                "Member not found."
    //            )
    //        );
    //    }

    //    return Ok(
    //        new ApiResponse<bool>(
    //            true,
    //            "Member deleted successfully."
    //        )
    //    );
    //}

    //[HttpGet("get-member-by-id/{memberId:int}")]
    //public async Task<IActionResult> GetMemberByIdAsync(int memberId, CancellationToken cancellationToken)
    //{
    //    var result = await _memberService.GetMemberByIdAsync(memberId, cancellationToken);
    //    return Ok(new ApiResponse<MemberDto>(
    //              result,
    //              "Get Member successfully."
    //              ));

    //}

    //[HttpPut("update-member")]
    //public async Task<IActionResult> UpdateMemberAsync([FromBody] MemberDto memberDto, CancellationToken cancellationToken)
    //{
    //    var result = await _memberService.UpdateMemberAsync(memberDto, cancellationToken);

    //    if (!result)
    //    {
    //        return NotFound(
    //            new ApiResponse<bool>(
    //                false,
    //                "Member not Updated."
    //            )
    //        );
    //    }

    //    return Ok(
    //        new ApiResponse<bool>(
    //            true,
    //            "Member Updated successfully."
    //        )
    //    );
    //}
}
