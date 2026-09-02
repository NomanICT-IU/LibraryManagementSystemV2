namespace LibraryManagementSystemV2.BLL.Dtos;

public class MemberListResponseDto
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public List<MemberDto> Members { get; set; }
    public int TotalRecords { get; set; }
}