CREATE TABLE [Security].[Users] (
    [UserId]       INT            IDENTITY (1, 1) NOT NULL,
    [UserName]     NVARCHAR (100) NOT NULL,
    [Email]        NVARCHAR (255) NOT NULL,
    [PasswordHash] NVARCHAR (500) NOT NULL,
    [FullName]     NVARCHAR (100) NOT NULL,
    [IsActive]     BIT            NOT NULL,
    [CreatedAt]    DATETIME       NOT NULL,
    [UpdateAt]     DATETIME       NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserId] ASC)
);

