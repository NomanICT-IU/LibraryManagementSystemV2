namespace LibraryManagementSystemV2.DAL.Entites;

public class MemberDetails
{
    public int MemberId { get; set; }
    public string Name { get; set; }
    public string MemberCode { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public int TotalBorrowedBooks { get; set; }
    public string Status { get; set; }
}
