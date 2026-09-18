using static LibraryManagementSystemV2.DAL.Repository.IRoleRepository;

namespace LibraryManagementSystemV2.DAL;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDataAccess(this IServiceCollection services,
        string connectionString)
    {
        services.AddScoped<IDbConnection>(sp =>
        {
            return new SqlConnection(connectionString);
        });
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IBookCopyRepository, BookCopyRepository>();
        services.AddScoped<IMemberRepository, MemberRepository>();
        services.AddScoped<IBorrowRecordRepository, BorrowRecordRepository>();
        services.AddScoped<IDashboardInformationRepository, DashboardInformationRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPermissionRepository, PermissionRepository>();


        return services;
    }

}
