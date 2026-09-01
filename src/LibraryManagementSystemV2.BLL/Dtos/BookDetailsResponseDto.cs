namespace LibraryManagementSystemV2.BLL.Dtos;

public class BookDetailsResponseDto
{
    public List<BookInformationDto> BookInformationDto { get; set; }
    public List<BookAvailabilitySummaryDto> BookAvailabilitySummaryDto { get; set; }
    public List<CopyInformationDto> CopyInformationDto { get; set; }
}
