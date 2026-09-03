using System.ComponentModel.DataAnnotations;

namespace Lms.Mvc.Models;

public class BookCopyModel
{
    public int CopyId { get; set; }

    [Required(ErrorMessage = "Copy Code is required.")]
    public string CopyCode { get; set; }

    [Required(ErrorMessage = "Please select a book.")]
    public int BookId { get; set; }

    [Required(ErrorMessage = "Please select a status")]
    public int Status { get; set; }
}
