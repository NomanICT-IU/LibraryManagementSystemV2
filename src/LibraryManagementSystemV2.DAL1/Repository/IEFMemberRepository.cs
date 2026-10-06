using LibraryManagementSystemV2.DAL1.Entities;

namespace LibraryManagementSystemV2.DAL1.Repository;

public interface IEFMemberRepository
{
    Task<List<MemberBorrowRecordDto>> GetBorrowRecordsByMemberIdAsync(int memberId, CancellationToken cancellationToken);
}

public class EFMemberRepository : IEFMemberRepository
{
    private readonly LmsDbContext _context;

    public EFMemberRepository(LmsDbContext context)
    {
        _context = context;
    }

    public async Task<List<MemberBorrowRecordDto>> GetBorrowRecordsByMemberIdAsync(int memberId, CancellationToken cancellationToken)
    {
        var result = await _context.BorrowRecords
            .Where(br => br.MemberId == memberId)
            .Join(
                _context.BookCopies,
                br => br.CopyId,
                bc => bc.CopyId,
                (br, bc) => new { br, bc }
            )
            .Join(
                _context.Books,
                x => x.bc.BookId,
                b => b.BookId,
                (x, b) => new MemberBorrowRecordDto
                {
                    Title = b.Title,
                    IssueDate = x.br.IssueDate,
                    DueDate = x.br.DueDate,
                    ReturnDate = x.br.ReturnDate
                }
            )
            .ToListAsync(cancellationToken);

        return result;
    }
}