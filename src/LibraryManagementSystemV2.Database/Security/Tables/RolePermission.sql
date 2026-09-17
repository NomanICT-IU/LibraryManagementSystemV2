CREATE TABLE [Security].[RolePermission] (
    [RolePermissionId] INT      IDENTITY (1, 1) NOT NULL,
    [RoleId]           INT      NOT NULL,
    [PermissionId]     INT      NOT NULL,
    [AssignedAt]       DATETIME NOT NULL,
    CONSTRAINT [PK_RolePermission] PRIMARY KEY CLUSTERED ([RolePermissionId] ASC),
    CONSTRAINT [FK_RolePermission_Permissions] FOREIGN KEY ([PermissionId]) REFERENCES [Security].[Permissions] ([PermissionId]),
    CONSTRAINT [FK_RolePermission_Roles] FOREIGN KEY ([RoleId]) REFERENCES [Security].[Roles] ([RoleId])
);

