namespace LibraryManagementSystemV2.DAL.Entites;

public class BookCopyDetailsReponse
{
    public int TotalRecords { get; set; }
    public List<BookCopyDetails> BookCopyList { get; set; }

}


public class BookCopyDetails
{
    public int CopyId { get; set; }
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public string CopyCode { get; set; }
    public string Status { get; set; }
    public string BorrowedBy { get; set; }
    public DateTime? DueDate { get; set; }
}
