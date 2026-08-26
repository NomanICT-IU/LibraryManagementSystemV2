namespace LibraryManagementSystemV2.BLL.Services;

public interface IBorrowRecordService
{
    public Task<BorrowRecordDto> CreateBorrowRecordAsync(BorrowRecordDto recordDto, CancellationToken cancellationToken);
    public Task<bool> UpdateBorrowRecordAsync(BorrowRecordDto recordDto, CancellationToken cancellationToken);
    public Task<bool> DeleteBorrowRecordAsync(int borrowId, CancellationToken cancellationToken);
    public Task<BorrowRecordDto> GetBorrowRecordByIdAsync(int borrowId, CancellationToken cancellationToken);
}
public class BorrowRecordService : IBorrowRecordService
{
    private readonly IBorrowRecordRepository _borrowRecordRepository;

    public BorrowRecordService(IBorrowRecordRepository borrowRecordRepository)
    {
        _borrowRecordRepository = borrowRecordRepository;
    }
    public async Task<BorrowRecordDto> CreateBorrowRecordAsync(BorrowRecordDto recordDto, CancellationToken cancellationToken)
    {
        var record = recordDto.Adapt<BorrowRecord>();
        var result = await _borrowRecordRepository.CreateBorrowRecordAsync(record, cancellationToken);
        return result.Adapt<BorrowRecordDto>();
    }
    public Task<bool> DeleteBorrowRecordAsync(int borrowId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<BorrowRecordDto> GetBorrowRecordByIdAsync(int borrowId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateBorrowRecordAsync(BorrowRecordDto recordDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}