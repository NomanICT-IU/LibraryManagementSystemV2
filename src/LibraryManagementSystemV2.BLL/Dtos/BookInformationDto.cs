namespace LibraryManagementSystemV2.BLL.Dtos;

public class BookInformationDto
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public string Category { get; set; }
}