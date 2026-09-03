namespace LibraryManagementSystemV2.BLL.Dtos
{
    public class BookCopyResponseDto
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public List<BookCopiesDto> BookCopies { get; set; }

    }
    public class BookCopiesDto
    {
        public int CopyId { get; set; }
        public string CopyCode { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
    }
}