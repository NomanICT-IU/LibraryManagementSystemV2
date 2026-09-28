using System.ComponentModel.DataAnnotations;

public class RoleModel
{
    public int RoleId { get; set; }

    [Required(ErrorMessage = "Role name is required.")]
    [StringLength(100, ErrorMessage = "Role name cannot exceed 100 characters.")]
    [Display(Name = "Role Name")]
    public string RoleName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Role code is required.")]
    [StringLength(20, ErrorMessage = "Role code cannot exceed 20 characters.")]
    [Display(Name = "Role Code")]
    public string RoleCode { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    [Display(Name = "Description")]
    public string? Description { get; set; }


    public bool IsActive { get; set; } = true;


    public DateTime CreatedAt { get; set; }


    public DateTime UpdatedAt { get; set; }
}