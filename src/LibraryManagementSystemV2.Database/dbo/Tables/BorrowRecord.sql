CREATE TABLE [dbo].[BorrowRecord] (
    [BorrowId]   INT      IDENTITY (1, 1) NOT NULL,
    [CopyId]     INT      NOT NULL,
    [MemberId]   INT      NOT NULL,
    [IssueDate]  DATETIME NOT NULL,
    [DueDate]    DATETIME NOT NULL,
    [ReturnDate] DATETIME NULL,
    CONSTRAINT [PK_BorrowRecord] PRIMARY KEY CLUSTERED ([BorrowId] ASC),
    CONSTRAINT [CK_BorrowRecord_DueDate_GreaterThan_IssueDate] CHECK ([DueDate]>[IssueDate]),
    CONSTRAINT [FK_BorrowRecord_BookCopy] FOREIGN KEY ([CopyId]) REFERENCES [dbo].[BookCopy] ([CopyId]),
    CONSTRAINT [FK_BorrowRecord_Member] FOREIGN KEY ([MemberId]) REFERENCES [dbo].[Member] ([MemberId]),
    CONSTRAINT [UQ_BorrowRecord_CopyId] UNIQUE NONCLUSTERED ([CopyId] ASC)
);

