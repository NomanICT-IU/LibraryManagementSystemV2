using System.ComponentModel.DataAnnotations;

namespace Lms.Mvc.Models;

public class MemberModel
{
    public int MemberId { get; set; }

    [Required(ErrorMessage = "Member code is required.")]
    public string MemberCode { get; set; }

    [Required(ErrorMessage = "Name is required.")]

    public string Name { get; set; }

    [Required(ErrorMessage = "Phone number is required.")]
    public string Phone { get; set; }


    [Required(ErrorMessage = "Email is required.")]

    public string Email { get; set; }

    [Required(ErrorMessage = "Address is required.")]

    public string Address { get; set; }

    [Required(ErrorMessage = "Please select a valid status.")]
    public int Status { get; set; }
}