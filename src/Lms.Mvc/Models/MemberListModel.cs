namespace Lms.Mvc.Models
{
    public class MemberListModel
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public List<MemberModel> Members { get; set; }
        public int TotalRecords { get; set; }
    }
}
