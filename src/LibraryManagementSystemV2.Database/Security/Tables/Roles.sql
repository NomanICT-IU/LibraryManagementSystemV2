CREATE TABLE [Security].[Roles] (
    [RoleId]      INT            IDENTITY (1, 1) NOT NULL,
    [RoleName]    NVARCHAR (255) NOT NULL,
    [Description] NVARCHAR (255) NULL,
    [IsActive]    BIT            NOT NULL,
    [CreatedAt]   DATETIME       NOT NULL,
    [UpdatedAt]   DATETIME       NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED ([RoleId] ASC)
);

