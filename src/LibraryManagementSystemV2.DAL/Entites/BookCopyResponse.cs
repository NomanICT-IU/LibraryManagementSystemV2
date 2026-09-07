namespace LibraryManagementSystemV2.DAL.Entites;

public class BookCopyResponse
{
    public int BookId { get; set; }
    public int CopyId { get; set; }
    public string CopyCode { get; set; }
    public string Title { get; set; }
    public int Status { get; set; }
}