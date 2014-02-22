IF object_id(N'[dbo].[FK_dbo.AspNetUserClaims_dbo.AspNetUsers_User_Id]', N'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_User_Id]
IF object_id(N'[dbo].[FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]', N'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
IF object_id(N'[dbo].[FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]', N'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
IF object_id(N'[dbo].[FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]', N'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
IF EXISTS (SELECT name FROM sys.indexes WHERE name = N'IX_User_Id' AND object_id = object_id(N'[dbo].[AspNetUserClaims]', N'U'))
    DROP INDEX [IX_User_Id] ON [dbo].[AspNetUserClaims]
IF EXISTS (SELECT name FROM sys.indexes WHERE name = N'IX_UserId' AND object_id = object_id(N'[dbo].[AspNetUserRoles]', N'U'))
    DROP INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
IF EXISTS (SELECT name FROM sys.indexes WHERE name = N'IX_RoleId' AND object_id = object_id(N'[dbo].[AspNetUserRoles]', N'U'))
    DROP INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
IF EXISTS (SELECT name FROM sys.indexes WHERE name = N'IX_UserId' AND object_id = object_id(N'[dbo].[AspNetUserLogins]', N'U'))
    DROP INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
DROP TABLE [dbo].[AspNetUserRoles]
DROP TABLE [dbo].[AspNetUserLogins]
DROP TABLE [dbo].[AspNetUserClaims]
DROP TABLE [dbo].[AspNetUsers]
DROP TABLE [dbo].[AspNetRoles]
DROP TABLE [dbo].[__MigrationHistory]
