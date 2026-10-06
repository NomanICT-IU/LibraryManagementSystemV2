namespace LibraryManagementSystemV2.DAL1.Configuration;

public class BorrowRecordsConfiguration : IEntityTypeConfiguration<BorrowRecord>
{
    public void Configure(EntityTypeBuilder<BorrowRecord> builder)
    {
        builder.ToTable("BorrowRecords");

        builder.HasKey(x => x.BorrowId);
    }
}
