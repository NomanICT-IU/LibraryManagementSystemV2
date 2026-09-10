namespace LibraryManagementSystemV2.BLL.Dtos;

public class BookDetailsResponseDto
{
    public List<BookInformationDto> BookInformation { get; set; }
    public List<BookAvailabilitySummaryDto> BookSummary { get; set; }
    public List<CopyInformationDto> CopyInformation { get; set; }
}
