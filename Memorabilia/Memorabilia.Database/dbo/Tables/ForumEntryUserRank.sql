CREATE TABLE [dbo].[ForumEntryUserRank] (
    [Id]           INT IDENTITY (1, 1) NOT NULL,
    [ForumEntryId] INT NOT NULL,
    [UserId]       INT NOT NULL,
    CONSTRAINT [PK_ForumEntryUserRank] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ForumEntryUserRank_ForumEntry] FOREIGN KEY ([ForumEntryId]) REFERENCES [dbo].[ForumEntry] ([Id]),
    CONSTRAINT [FK_ForumEntryUserRank_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

