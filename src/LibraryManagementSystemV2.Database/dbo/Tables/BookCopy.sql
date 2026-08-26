CREATE TABLE [dbo].[BookCopy] (
    [CopyId]   INT           IDENTITY (1, 1) NOT NULL,
    [CopyCode] NVARCHAR (50) NOT NULL,
    [BookId]   INT           NOT NULL,
    [Status]   INT           NOT NULL,
    CONSTRAINT [PK_BookCopy] PRIMARY KEY CLUSTERED ([CopyId] ASC),
    CONSTRAINT [FK_BookCopy_Book] FOREIGN KEY ([BookId]) REFERENCES [dbo].[Book] ([BookId]),
    CONSTRAINT [UQ_Book_CopyCode] UNIQUE NONCLUSTERED ([CopyCode] ASC)
);

