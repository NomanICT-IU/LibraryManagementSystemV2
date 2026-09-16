CREATE TABLE [Security].[Permissions] (
    [PermissionId]   INT            IDENTITY (1, 1) NOT NULL,
    [PermissionName] NVARCHAR (100) NOT NULL,
    [PermissionCode] NCHAR (100)    NOT NULL,
    [Description]    NVARCHAR (255) NULL,
    [IsActive]       BIT            NOT NULL,
    [CreatedAt]      DATETIME       NOT NULL,
    [UpdatedAt]      DATETIME       NULL,
    CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED ([PermissionId] ASC)
);

