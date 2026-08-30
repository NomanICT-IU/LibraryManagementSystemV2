namespace LibraryManagementSystemV2.DAL.Entites;

public class MemberDetailsResponse
{
    public MemberProfile Member { get; set; }
    public MemberBorrowSummary BorrowSummery { get; set; }
    public List<MemberBorrowedHistory> BorrowedHistory { get; set; }
    public List<MemberReturnHistory> ReturnHistory { get; set; }
}
