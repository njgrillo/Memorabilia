CREATE TABLE [dbo].[ForumEntryImage] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [ForumEntryId]  INT            NOT NULL,
    [ImageFileName] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_ForumEntryImage] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ForumEntryImage_ForumEntry] FOREIGN KEY ([ForumEntryId]) REFERENCES [dbo].[ForumEntry] ([Id])
);

