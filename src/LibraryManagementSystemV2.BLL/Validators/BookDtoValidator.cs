namespace LibraryManagementSystemV2.BLL.Validators;

public class BookDtoValidator : AbstractValidator<BookDto>
{
    public BookDtoValidator()
    {

        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title is required.")
            .MaximumLength(256)
            .WithMessage("Title cannot exceed 256 characters.");

        RuleFor(x => x.Author)
            .NotEmpty()
            .WithMessage("Author is required.")
            .MaximumLength(50)
            .WithMessage("Author cannot exceed 50 characters.");

        RuleFor(x => x.ISBN)
            .NotEmpty()
            .WithMessage("ISBN is required.")
            .MaximumLength(50)
            .WithMessage("ISBN cannot exceed 50 characters.");

        RuleFor(x => x.Category)
            .NotEmpty()
            .WithMessage("Category is required.")
            .MaximumLength(50)
            .WithMessage("Category cannot exceed 50 characters.");
    }
}
