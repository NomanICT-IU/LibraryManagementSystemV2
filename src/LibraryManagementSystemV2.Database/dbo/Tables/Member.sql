CREATE TABLE [dbo].[Member] (
    [MemberId]   INT            IDENTITY (1, 1) NOT NULL,
    [MemberCode] NVARCHAR (50)  NOT NULL,
    [Name]       NVARCHAR (100) NOT NULL,
    [Phone]      NVARCHAR (20)  NOT NULL,
    [Email]      NVARCHAR (50)  NULL,
    [Address]    NVARCHAR (50)  NOT NULL,
    [Status]     INT            NOT NULL,
    CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED ([MemberId] ASC)
);

