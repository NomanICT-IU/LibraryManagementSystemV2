namespace LibraryManagementSystemV2.BLL.Validators;

public class BorrowRecordDtoValidator : AbstractValidator<BorrowRecordDto>
{
    public BorrowRecordDtoValidator()
    {
        RuleFor(x => x.MemberId)
           .GreaterThan(0)
           .WithMessage("MemberId must be greater than 0.");

        RuleFor(x => x.IssueDate)
            .NotEmpty()
            .WithMessage("Issue date is required.");

        RuleFor(x => x.DueDate)
            .NotEmpty()
            .WithMessage("Due date is required.")
            .GreaterThan(x => x.IssueDate)
            .WithMessage("Due date must be after issue date.");

        RuleFor(x => x.ReturnDate)
            .GreaterThanOrEqualTo(x => x.IssueDate)
            .When(x => x.ReturnDate.HasValue)
            .WithMessage("Return date cannot be before issue date.");
    }

}
