namespace LibraryManagementSystemV2.BLL.Dtos;

public class BookListResponseDto
{

    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalRecords { get; set; }
    public List<BookDto> BookList { get; set; }
}