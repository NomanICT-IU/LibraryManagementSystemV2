namespace LibraryManagementSystemV2.BLL.Validators;

public class roleDtoValidator : AbstractValidator<RoleDto>
{
    public roleDtoValidator()
    {
        RuleFor(x => x.RoleName)
           .NotEmpty()
           .WithMessage("Role name is required.")
           .MaximumLength(50)
           .WithMessage("Role name cannot exceed 50 characters.");

        RuleFor(x => x.RoleCode)
            .NotEmpty()
            .WithMessage("Role code is required.")
            .MaximumLength(20)
            .WithMessage("Role code cannot exceed 20 characters.");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required.")
            .MaximumLength(250)
            .WithMessage("Description cannot exceed 250 characters.");

        RuleFor(x => x.IsActive)
            .NotNull()
            .WithMessage("Active status is required.");

        RuleFor(x => x.CreatedAt)
            .NotEmpty()
            .WithMessage("Created date is required.");
    }
}
