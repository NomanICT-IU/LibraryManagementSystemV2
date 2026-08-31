namespace LibraryManagementSystemV2.BLL.Validators;

public class MemberDtoValidator : AbstractValidator<MemberDto>
{
    public MemberDtoValidator()
    {
        RuleFor(x => x.MemberCode)
           .NotEmpty()
           .WithMessage("Member code is required.")
           .MaximumLength(50)
           .WithMessage("Member code cannot exceed 50 characters.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(100)
            .WithMessage("Name cannot exceed 100 characters.");

        RuleFor(x => x.Phone)
            .NotEmpty()
            .WithMessage("Phone is required.")
            .MaximumLength(20)
            .WithMessage("Phone cannot exceed 20 characters.");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .EmailAddress()
            .WithMessage("Invalid email address.")
            .MaximumLength(50)
            .WithMessage("Email cannot exceed 50 characters.");

        RuleFor(x => x.Address)
            .NotEmpty()
            .WithMessage("Address is required.")
            .MaximumLength(256)
            .WithMessage("Address cannot exceed 256 characters.");

        RuleFor(x => x.Status)
            .InclusiveBetween(0, 1)
            .WithMessage("Status must be 0 (Inactive) or 1 (Active).");
    }
}
