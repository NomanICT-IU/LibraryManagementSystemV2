using LibraryManagementSystemV2.DAL1.Entities;
using LibraryManagementSystemV2.DAL1.Repository;

namespace LibraryManagementSystemV2.BLL.Services;

public interface IMemberService
{
    public Task<MemberDto> CreateMemberAsync(MemberDto memberDto, CancellationToken cancellationToken);
    public Task<bool> UpdateMemberAsync(MemberDto memberDto, CancellationToken cancellationToken);
    public Task<bool> DeleteMemberAsync(int memberId, CancellationToken cancellationToken);
    public Task<MemberDto> GetMemberByIdAsync(int memberId, CancellationToken cancellationToken);
    public Task<MemberDetailsDto> FindMemberAsync(string searchText, CancellationToken cancellationToken);
    public Task<MemberDetailsResponseDto> GetMemberDetailsAsync(string searchBy, string searchText, CancellationToken cancellationToken);
    public Task<MemberListResponseDto> GetMemberListAsync(string searchText, int pageNumber, int pageSize, CancellationToken cancellationToken);

    Task<List<MemberBorrowRecordDto>> GetBorrowRecordsByMemberIdAsync(int memberId, CancellationToken cancellationToken);
}

public class MemberService : IMemberService
{
    private readonly IMemberRepository _memberRepository;
    private readonly IEFMemberRepository _eFMemberRepository;

    public MemberService(IMemberRepository memberRepository, IEFMemberRepository eFMemberRepository)
    {
        _memberRepository = memberRepository;
        _eFMemberRepository = eFMemberRepository;
    }
    public Task<List<MemberBorrowRecordDto>> GetBorrowRecordsByMemberIdAsync(int memberId, CancellationToken cancellationToken)
    {
        return _eFMemberRepository.GetBorrowRecordsByMemberIdAsync(memberId, cancellationToken); ;
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


    public async Task<MemberDetailsDto> FindMemberAsync(string searchText, CancellationToken cancellationToken)
    {
        var membertails = await _memberRepository.FindMemberAsync(searchText, cancellationToken);
        return membertails.Adapt<MemberDetailsDto>();
    }

    public async Task<MemberDetailsResponseDto> GetMemberDetailsAsync(string searchBy, string searchText, CancellationToken cancellationToken)
    {
        var memberDetailsResponse = await _memberRepository.GetMemberDetailsAsync(searchBy, searchText, cancellationToken);

        return memberDetailsResponse.Adapt<MemberDetailsResponseDto>();
    }

    public async Task<MemberListResponseDto> GetMemberListAsync(string searchText, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var memberList = await _memberRepository.GetMemberListAsync(searchText, pageNumber, pageSize, cancellationToken);

        return new MemberListResponseDto
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            Members = memberList.Members.Adapt<List<MemberDto>>(),
            TotalRecords = memberList.TotalRecords
        };
    }


}