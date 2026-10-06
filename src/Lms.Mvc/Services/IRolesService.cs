//using Lms.Mvc.Models;

//namespace Lms.Mvc.Services;

//public interface IRolesService
//{
//    Task<ApiResponse<bool>> CreateRoleAsync(RoleModel roleModel, CancellationToken cancellationToken);
//    Task<ApiResponse<bool>> UpdateRoleAsync(RoleModel roleModel, CancellationToken cancellationToken);
//    Task<ApiResponse<RoleModel?>> GetRoleByIdAsync(int roleId, CancellationToken cancellationToken);
//    Task<ApiResponse<bool>> DeleteRoleAsync(int roleId, CancellationToken cancellationToken);
//    Task<ApiResponse<IEnumerable<RoleModel>>> GetRoleList(CancellationToken cancellationToken);
//}

//public class RolesService : IRolesService
//{
//    private readonly HttpClient _httpClientFactory;
//    public RolesService(IHttpClientFactory httpClientFactory)
//    {
//        _httpClientFactory = httpClientFactory.CreateClient("LMSApi");
//    }
//    public async Task<ApiResponse<bool>> CreateRoleAsync(RoleModel roleModel, CancellationToken cancellationToken)
//    {
//        var response = await _httpClientFactory.PostAsJsonAsync("api/Roles/create-role", roleModel, cancellationToken);
//        response.EnsureSuccessStatusCode();
//        var result = await response.Content
//           .ReadFromJsonAsync<ApiResponse<bool>>(
//               cancellationToken);
//        return result!;
//    }

//    public Task<ApiResponse<bool>> DeleteRoleAsync(int roleId, CancellationToken cancellationToken)
//    {
//        throw new NotImplementedException();
//    }

//    public Task<ApiResponse<RoleModel>> GetRoleByIdAsync(int roleId, CancellationToken cancellationToken)
//    {
//        throw new NotImplementedException();
//    }

//    public Task<ApiResponse<IEnumerable<RoleModel>>> GetRoleList(CancellationToken cancellationToken)
//    {
//        throw new NotImplementedException();
//    }

//    public Task<ApiResponse<bool>> UpdateRoleAsync(RoleModel roleModel, CancellationToken cancellationToken)
//    {
//        throw new NotImplementedException();
//    }

//}
