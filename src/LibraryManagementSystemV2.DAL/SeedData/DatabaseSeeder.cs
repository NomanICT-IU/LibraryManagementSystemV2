using LibraryManagementSystemV2.Shared.Constants;

namespace LibraryManagementSystemV2.DAL.SeedData;

public static class DatabaseSeeder
{
    public static void SeedPermissions(string connectionString)
    {
        using var connection = new SqlConnection(connectionString);

        connection.Open();

        using var transaction = connection.BeginTransaction();

        try
        {
            const string sql = """
                IF NOT EXISTS
                (
                    SELECT 1
                    FROM [Security].[Permissions]
                    WHERE [PermissionCode] = @PermissionCode
                )
                BEGIN
                    INSERT INTO [Security].[Permissions]
                    (
                        [PermissionName],
                        [PermissionCode],
                        [Description],
                        [IsActive],
                        [CreatedAt]
                    )
                    VALUES
                    (
                        @PermissionName,
                        @PermissionCode,
                        @Description,
                        1,
                        GETUTCDATE()
                    );
                END
                """;

            foreach (var permission in Permissions.GetAll())
            {
                var parameters = new
                {
                    PermissionName = permission,
                    PermissionCode = permission,
                    Description = $"Permission: {permission}"
                };

                connection.Execute(
                    sql,
                    parameters,
                    transaction);
            }

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }
}