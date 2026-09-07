using System.ComponentModel.DataAnnotations;

namespace Lms.Mvc.Models;

public class BookCopyModel
{
    public int CopyId { get; set; }

    [Required(ErrorMessage = "Copy Code is required.")]
    public string CopyCode { get; set; }

    public int BookId { get; set; }

    public int Status { get; set; }
}
