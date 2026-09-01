using System.ComponentModel.DataAnnotations;

namespace Lms.Mvc.Models;

public class BookModel
{
    public int BookId { get; set; }
    [Required(ErrorMessage = "Title is required!")]
    public string Title { get; set; }
    [Required(ErrorMessage = "Author name is required!")]
    public string Author { get; set; }
    [Required(ErrorMessage = "ISBn number is required!")]
    public string ISBN { get; set; }
    public string Category { get; set; }
}
