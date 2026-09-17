namespace LibraryManagementSystemV2.BLL.Dtos;

public class RolePermissionDto
{
    public int RolePermissionId { get; set; }
    public int RoleId { get; set; }
    public int PermissionId { get; set; }
    public DateTime AssignedAt { get; set; }
}
