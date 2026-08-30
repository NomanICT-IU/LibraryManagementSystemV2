namespace LibraryManagementSystemV2.BLL.Dtos;

public class MemberDetailsResponseDto
{
    public MemberProfileDto Member { get; set; }
    public MemberBorrowSummaryDto BorrowSummery { get; set; }
    public List<MemberBorrowedHistoryDto> BorrowedHistory { get; set; }
    public List<MemberReturnHistoryDto> ReturnHistory { get; set; }
}
