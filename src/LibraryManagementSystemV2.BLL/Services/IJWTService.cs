namespace LibraryManagementSystemV2.BLL.Services;

public interface IJWTService
{
    string GenerateToken(int userId, string userName, string roleName);
}
public class JWTService(IConfiguration configuration) : IJWTService
{
    public string GenerateToken(int userId, string userName, string roleName)
    {
        throw new NotImplementedException();
    }
}