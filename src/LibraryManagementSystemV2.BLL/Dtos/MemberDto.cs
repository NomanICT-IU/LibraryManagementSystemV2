namespace LibraryManagementSystemV2.BLL.Dtos;

public class MemberDto
{
    public int MemberId { get; set; }
    public string MemberCode { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public int Status { get; set; }
}
