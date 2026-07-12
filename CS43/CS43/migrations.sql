IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [article] (
    [ArticleId] int NOT NULL IDENTITY,
    [Title] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_article] PRIMARY KEY ([ArticleId])
);

CREATE TABLE [Tags] (
    [TagId] nvarchar(20) NOT NULL,
    [Content] ntext NOT NULL,
    CONSTRAINT [PK_Tags] PRIMARY KEY ([TagId])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260712080701_V0', N'9.0.9');

EXEC sp_rename N'[article].[Title]', N'Name', 'COLUMN';

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260712081437_V1', N'9.0.9');

ALTER TABLE [article] ADD [Content] ntext NOT NULL DEFAULT N'';

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260712082004_V', N'9.0.9');

ALTER TABLE [Tags] DROP CONSTRAINT [PK_Tags];

DECLARE @var sysname;
SELECT @var = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tags]') AND [c].[name] = N'TagId');
IF @var IS NOT NULL EXEC(N'ALTER TABLE [Tags] DROP CONSTRAINT [' + @var + '];');
ALTER TABLE [Tags] DROP COLUMN [TagId];

ALTER TABLE [Tags] ADD [TagIdNew] int NOT NULL IDENTITY;

ALTER TABLE [Tags] ADD CONSTRAINT [PK_Tags] PRIMARY KEY ([TagIdNew]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260712082252_V3-removeTagId', N'9.0.9');

EXEC sp_rename N'[Tags].[TagIdNew]', N'TagId', 'COLUMN';

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260712082349_V3-RenameTagId', N'9.0.9');

CREATE TABLE [ArticleTags] (
    [ArticleTagId] int NOT NULL IDENTITY,
    [TagId] int NOT NULL,
    [ArticleId] int NOT NULL,
    CONSTRAINT [PK_ArticleTags] PRIMARY KEY ([ArticleTagId]),
    CONSTRAINT [FK_ArticleTags_Tags_TagId] FOREIGN KEY ([TagId]) REFERENCES [Tags] ([TagId]) ON DELETE CASCADE,
    CONSTRAINT [FK_ArticleTags_article_ArticleId] FOREIGN KEY ([ArticleId]) REFERENCES [article] ([ArticleId]) ON DELETE CASCADE
);

CREATE UNIQUE INDEX [IX_ArticleTags_ArticleId_TagId] ON [ArticleTags] ([ArticleId], [TagId]);

CREATE INDEX [IX_ArticleTags_TagId] ON [ArticleTags] ([TagId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260712083007_V4', N'9.0.9');

COMMIT;
GO

