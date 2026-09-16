CREATE TABLE [Security].[UserRole] (
    [UserRoleId] INT      IDENTITY (1, 1) NOT NULL,
    [UserId]     INT      NOT NULL,
    [RoleId]     INT      NOT NULL,
    [AssignedAt] DATETIME NOT NULL,
    CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED ([UserRoleId] ASC),
    CONSTRAINT [FK_UserRole_Roles] FOREIGN KEY ([RoleId]) REFERENCES [Security].[Roles] ([RoleId]),
    CONSTRAINT [FK_UserRole_Users] FOREIGN KEY ([UserId]) REFERENCES [Security].[Users] ([UserId])
);

