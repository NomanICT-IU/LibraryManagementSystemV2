namespace LibraryManagementSystemV2.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MemberController(IMemberService _memberService) : ControllerBase
{
    [HttpPost("create-member")]
    public async Task<IActionResult> CreateMemberAsync([FromBody] MemberDto memberDto, CancellationToken cancellationToken)
    {
        var result = await _memberService.CreateMemberAsync(memberDto, cancellationToken);

        return Ok(new ApiResponse<MemberDto>(
                  result,
                  "Member created successfully."
                  ));
    }

    [HttpDelete("delete-member/{memberId:int}")]
    public async Task<IActionResult> DeleteMemberAsync(int memberId, CancellationToken cancellationToken)
    {
        var result = await _memberService.DeleteMemberAsync(
            memberId,
            cancellationToken);

        if (!result)
        {
            return NotFound(
                new ApiResponse<bool>(
                    false,
                    "Member not found."
                )
            );
        }

        return Ok(
            new ApiResponse<bool>(
                true,
                "Member deleted successfully."
            )
        );
    }

    [HttpGet("get-member-by-id/{memberId:int}")]
    public async Task<IActionResult> GetMemberByIdAsync(int memberId, CancellationToken cancellationToken)
    {
        var result = await _memberService.GetMemberByIdAsync(memberId, cancellationToken);
        return Ok(new ApiResponse<MemberDto>(
                  result,
                  "Get Member successfully."
                  ));

    }

    [HttpPut("update-member")]
    public async Task<IActionResult> UpdateMemberAsync([FromBody] MemberDto memberDto, CancellationToken cancellationToken)
    {
        var result = await _memberService.UpdateMemberAsync(memberDto, cancellationToken);

        if (!result)
        {
            return NotFound(
                new ApiResponse<bool>(
                    false,
                    "Member not Updated."
                )
            );
        }

        return Ok(
            new ApiResponse<bool>(
                true,
                "Member Updated successfully."
            )
        );
    }

    [HttpGet("find-member-by-member-id-or-member-phone")]
    public async Task<IActionResult> FindMemberAsync([FromQuery] string searchText, CancellationToken cancellationToken)
    {
        var result = await _memberService.FindMemberAsync(searchText, cancellationToken);
        return Ok(
                   new ApiResponse<MemberDetailsDto>(result,
                   "Member details retrive successfully."
                   ));
    }
    [HttpGet("get-member-details-by-member-id-or-name-or-phone ")]
    public async Task<IActionResult> GetMemberDetailsAsync([FromQuery] string searchBy, [FromQuery] string searchText, CancellationToken cancellationToken)
    {
        var result = await _memberService.GetMemberDetailsAsync(searchBy, searchText, cancellationToken);
        return Ok(
                  new ApiResponse<MemberDetailsResponseDto>
                  (result,
                  "Member data retrive successfully."
                      ));
    }

}
