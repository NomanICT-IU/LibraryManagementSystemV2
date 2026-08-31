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
        services.AddValidatorsFromAssemblyContaining<BookDtoValidator>();
        return services;
    }
}
