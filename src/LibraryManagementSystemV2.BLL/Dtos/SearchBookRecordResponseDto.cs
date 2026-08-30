namespace LibraryManagementSystemV2.BLL.Dtos;

public class SearchBookRecordResponseDto
{
    public BookInformationDto Book { get; set; }
    public BookCopySummaryDto Summary { get; set; }
    public List<BookCopyDetailsDto> CopyDetails { get; set; }
    public List<BookCopyStatusDto> CopyStatus { get; set; }
}
