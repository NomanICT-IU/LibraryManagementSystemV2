namespace LibraryManagementSystemV2.BLL.Services;

public interface IBorrowRecordService
{
    public Task<BorrowRecordDetailsDto> CreateBorrowRecordAsync(BorrowRecordDto recordDto, CancellationToken cancellationToken);
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
    public async Task<BorrowRecordDetailsDto> CreateBorrowRecordAsync(BorrowRecordDto recordDto, CancellationToken cancellationToken)
    {
        var record = recordDto.Adapt<BorrowRecord>();
        var result = await _borrowRecordRepository.CreateBorrowRecordAsync(record, cancellationToken);
        return result.Adapt<BorrowRecordDetailsDto>();
    }
    public async Task<bool> DeleteBorrowRecordAsync(int borrowId, CancellationToken cancellationToken)
    {
        return await _borrowRecordRepository.DeleteBorrowRecordAsync(borrowId, cancellationToken);
    }

    public async Task<BorrowRecordDto> GetBorrowRecordByIdAsync(int borrowId, CancellationToken cancellationToken)
    {
        var result = await _borrowRecordRepository.GetBorrowRecordByIdAsync(borrowId, cancellationToken);
        return result.Adapt<BorrowRecordDto>();
    }

    public async Task<bool> UpdateBorrowRecordAsync(BorrowRecordDto recordDto, CancellationToken cancellationToken)
    {
        var record = recordDto.Adapt<BorrowRecord>();
        return await _borrowRecordRepository.UpdateBorrowRecordAsync(record, cancellationToken);

    }
}