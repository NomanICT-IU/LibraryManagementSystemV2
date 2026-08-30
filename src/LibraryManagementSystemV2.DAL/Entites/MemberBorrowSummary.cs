namespace LibraryManagementSystemV2.DAL.Entites;

public class MemberBorrowSummary
{
    public int TotalBorrowed { get; set; }
    public int CurrentlyBorrowed { get; set; }
    public int OverdueBooks { get; set; }
    public DateTime? LastBorrowed { get; set; }
}
