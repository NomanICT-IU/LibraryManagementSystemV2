namespace Lms.Mvc.Models.ViewModels;

public class MemberDetailsViewModel
{
    public string SearchBy { get; set; }
    public string SearchText { get; set; }
    public MemberProfileModel Member { get; set; }
    public MemberBorrowSummaryModel BorrowSummery { get; set; }
    public List<MemberBorrowedHistoryModel> BorrowedHistory { get; set; }
    public List<MemberReturnHistoryModel> ReturnHistory { get; set; }
}

public class MemberProfileModel
{
    public int MemberId { get; set; }
    public string Name { get; set; }
    public string MemberCode { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Status { get; set; }
}
public class MemberBorrowSummaryModel
{
    public int TotalBorrowed { get; set; }
    public int CurrentlyBorrowed { get; set; }
    public int OverdueBooks { get; set; }
    public DateTime? LastBorrowed { get; set; }

}
public class MemberBorrowedHistoryModel
{
    public int BorrowId { get; set; }
    public int BookId { get; set; }
    public string Title { get; set; }
    public string CopyCode { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime DueDate { get; set; }
}
public class MemberReturnHistoryModel
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public string CopyCode { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}

