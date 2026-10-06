namespace LibraryManagementSystemV2.DAL.Entites;

public class BookCopy
{
    public int CopyId { get; set; }
    public string CopyCode { get; set; }
    public int BookId { get; set; }
    public int Status { get; set; }
}
