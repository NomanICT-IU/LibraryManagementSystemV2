namespace LibraryManagementSystemV2.BLL.Validators;

public class BookCopyDtoValidator : AbstractValidator<BookCopyDto>
{
    public BookCopyDtoValidator()
    {
        RuleFor(x => x.CopyCode)
            .NotEmpty()
            .WithMessage("CopyCode is required.")
            .MaximumLength(50)
            .WithMessage("CopyCode cannot exceed 50 characters.");

        RuleFor(x => x.BookId)
            .GreaterThan(0)
            .WithMessage("BookId must be greater than 0.");

        RuleFor(x => x.Status)
            .InclusiveBetween(1, 2)
            .WithMessage("Status must be 1 (Available) or 2 (Borrowed).");
    }

}
