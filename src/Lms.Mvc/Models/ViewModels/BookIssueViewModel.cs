using System.ComponentModel.DataAnnotations;

namespace Lms.Mvc.Models.ViewModels;

public class BookIssueViewModel
{
    public BookIssueModel BookIssue { get; set; } = new();
    public BookDetailsModel Book { get; set; } = new();

    public MemberInformationModel Member { get; set; } = new();

    public IssueInformationModel Issue { get; set; } = new();
}

public class BookIssueModel
{
    public int CopyId { get; set; }
    public string MemberSearch { get; set; } = string.Empty;
    public string ReturnPage { get; set; } = string.Empty;

    public string SearchBy { get; set; } = string.Empty;

    public string SearchResult { get; set; } = string.Empty;
}
public class MemberInformationModel
{
    public int MemberId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string MemberCode { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public int TotalBorrowedBooks { get; set; }

    public string Status { get; set; } = string.Empty;
}

public class IssueInformationModel
{
    public int CopyId { get; set; }

    public int MemberId { get; set; }
    [Required]

    public DateTime? IssueDate { get; set; }
    [Required]

    public DateTime? DueDate { get; set; }
}

