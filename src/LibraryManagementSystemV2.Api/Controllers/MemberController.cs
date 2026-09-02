namespace LibraryManagementSystemV2.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MemberController(IMemberService _memberService) : ControllerBase
{
    [HttpPost("create-member")]
    public async Task<IActionResult> CreateMemberAsync([FromBody] MemberDto memberDto, CancellationToken cancellationToken)
    {
        var result = await _memberService.CreateMemberAsync(memberDto, cancellationToken);

        return Ok(new ApiResponse<MemberDto> { Data = result });
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
                new ApiResponse<bool> { Data = result }
            );
        }

        return Ok(
            new ApiResponse<bool> { Data = result }
        );
    }

    [HttpGet("get-member-by-id/{memberId:int}")]
    public async Task<IActionResult> GetMemberByIdAsync(int memberId, CancellationToken cancellationToken)
    {
        var result = await _memberService.GetMemberByIdAsync(memberId, cancellationToken);
        return Ok(new ApiResponse<MemberDto> { Data = result });

    }

    [HttpPut("update-member")]
    public async Task<IActionResult> UpdateMemberAsync([FromBody] MemberDto memberDto, CancellationToken cancellationToken)
    {
        var result = await _memberService.UpdateMemberAsync(memberDto, cancellationToken);

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

    [HttpGet("find-member-by-member-id-or-member-phone")]
    public async Task<IActionResult> FindMemberAsync([FromQuery] string searchText, CancellationToken cancellationToken)
    {
        var result = await _memberService.FindMemberAsync(searchText, cancellationToken);
        return Ok(
                   new ApiResponse<MemberDetailsDto> { Data = result });
    }
    [HttpGet("get-member-details-by-member-id-or-name-or-phone ")]
    public async Task<IActionResult> GetMemberDetailsAsync([FromQuery] string searchBy, [FromQuery] string searchText, CancellationToken cancellationToken)
    {
        var result = await _memberService.GetMemberDetailsAsync(searchBy, searchText, cancellationToken);
        return Ok(
                  new ApiResponse<MemberDetailsResponseDto>
                  { Data = result });
    }

    [HttpGet("get-member-list-Name-Id-phone-email-address")]
    public async Task<IActionResult> GetMemberListAsync(string searchText = "", int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var result = await _memberService.GetMemberListAsync(searchText, pageNumber, pageSize, cancellationToken);
        return Ok(
                  new ApiResponse<MemberListResponseDto>
                  { Data = result });
    }
}
