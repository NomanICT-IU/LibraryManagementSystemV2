namespace LibraryManagementSystemV2.BLL.Dtos;

public class RoleDto
{
    public int RoleId { get; set; }
    public string RoleName { get; set; }
    public string RoleCode { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
public class UserRoleDto
{
    public int UserRoleId { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public DateTime AssignedAt { get; set; }
}