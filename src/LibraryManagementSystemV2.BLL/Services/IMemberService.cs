namespace LibraryManagementSystemV2.BLL.Services;

public interface IMemberService
{
    public Task<MemberDto> CreateMemberAsync(MemberDto memberDto, CancellationToken cancellationToken);
    public Task<bool> UpdateMemberAsync(MemberDto memberDto, CancellationToken cancellationToken);
    public Task<bool> DeleteMemberAsync(int memberId, CancellationToken cancellationToken);
    public Task<MemberDto> GetMemberByIdAsync(int memberId, CancellationToken cancellationToken);
    public Task<MemberDetailsDto> GetMemberDetailsAsync(string searchText, CancellationToken cancellationToken);

}

public class MemberService : IMemberService
{
    private readonly IMemberRepository _memberRepository;

    public MemberService(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }
    public async Task<MemberDto> CreateMemberAsync(MemberDto memberDto, CancellationToken cancellationToken)
    {
        var member = memberDto.Adapt<Member>();
        var result = await _memberRepository.CreateMemberAsync(member, cancellationToken);

        return result.Adapt<MemberDto>();
    }

    public async Task<bool> DeleteMemberAsync(int memberId, CancellationToken cancellationToken)
    {
        return await _memberRepository.DeleteMemberAsync(memberId, cancellationToken);
    }

    public async Task<MemberDto> GetMemberByIdAsync(int memberId, CancellationToken cancellationToken)
    {
        var member = await _memberRepository.GetMemberByIdAsync(memberId, cancellationToken);
        return member.Adapt<MemberDto>();
    }

    public async Task<bool> UpdateMemberAsync(MemberDto memberDto, CancellationToken cancellationToken)
    {
        var member = memberDto.Adapt<Member>();
        return await _memberRepository.UpdateMemberAsync(member, cancellationToken);
    }


    public async Task<MemberDetailsDto> GetMemberDetailsAsync(string searchText, CancellationToken cancellationToken)
    {
        var membertails = await _memberRepository.GetMemberDetailsAsync(searchText, cancellationToken);
        return membertails.Adapt<MemberDetailsDto>();
    }

}