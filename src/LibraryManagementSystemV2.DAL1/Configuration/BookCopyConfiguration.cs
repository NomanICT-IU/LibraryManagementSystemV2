namespace LibraryManagementSystemV2.DAL1.Configuration;

public class BookCopyConfiguration : IEntityTypeConfiguration<BookCopy>
{
    public void Configure(EntityTypeBuilder<BookCopy> builder)
    {
        builder.ToTable("BookCopies");

        builder.HasKey(x => x.CopyId);
    }
}
