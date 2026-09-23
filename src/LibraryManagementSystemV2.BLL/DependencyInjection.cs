namespace LibraryManagementSystemV2.BLL;

public static class DependencyInjection
{

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IBookCopyService, BookCopyService>();
        services.AddScoped<IMemberService, MemberService>();
        services.AddScoped<IBorrowRecordService, BorrowRecordService>();
        services.AddScoped<IDashboardInformationService, DashboardInformationService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPermissionService, PermissionService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddSingleton<IPasswordHasher, Argon2idPasswordHasher>();
        services.AddSingleton<IJwtSigner, RsaJwtSigner>();

        services.AddValidatorsFromAssemblyContaining<BookDtoValidator>();
        return services;
    }
}
