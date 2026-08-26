namespace LibraryManagementSystemV2.DAL.Repository;

public interface IMemberRepository
{
    public Task<Member> CreateMemberAsync(Member member, CancellationToken cancellationToken);
    public Task<bool> UpdateMemberAsync(Member member, CancellationToken cancellationToken);
    public Task<bool> DeleteMemberAsync(int memberId, CancellationToken cancellationToken);
    public Task<Member> GetMemberByIdAsync(int memberId, CancellationToken cancellationToken);
}

public class MemberRepository : IMemberRepository
{
    private readonly IDbConnection _dbConnection;

    public MemberRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    public async Task<Member> CreateMemberAsync(Member member, CancellationToken cancellationToken)
    {
        var command = "dbo.CreateMember";
        var parameters = new DynamicParameters();
        parameters.Add("@MemberCode", member.MemberCode);
        parameters.Add("@Name", member.Name);
        parameters.Add("@Phone", member.Phone);
        parameters.Add("@Email", member.Email);
        parameters.Add("@Address", member.Address);
        parameters.Add("@Status", member.Status);

        return await _dbConnection.QuerySingleAsync<Member>(command, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> DeleteMemberAsync(int memberId, CancellationToken cancellationToken)
    {
        var command = "dbo.DeleteMember";
        var parameters = new DynamicParameters();
        parameters.Add("@MemberId", memberId);
        int effectedRows = await _dbConnection.ExecuteAsync(command, parameters, commandType: CommandType.StoredProcedure);
        return effectedRows > 0;
    }

    public async Task<Member> GetMemberByIdAsync(int memberId, CancellationToken cancellationToken)
    {
        var command = "dbo.GetMemberById";
        var parameters = new DynamicParameters();
        parameters.Add("@MemberId", memberId);

        return await _dbConnection.QuerySingleAsync<Member>(command, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> UpdateMemberAsync(Member member, CancellationToken cancellationToken)
    {
        var command = "dbo.UpdateMember";
        var parameters = new DynamicParameters();
        parameters.Add("@MemberId", member.MemberId);
        parameters.Add("@MemberCode", member.MemberCode);
        parameters.Add("@Name", member.Name);
        parameters.Add("@Phone", member.Phone);
        parameters.Add("@Email", member.Email);
        parameters.Add("@Address", member.Address);
        parameters.Add("@Status", member.Status);

        int effectedRows = await _dbConnection.ExecuteAsync(command, parameters, commandType: CommandType.StoredProcedure);
        return effectedRows > 0;
    }
}