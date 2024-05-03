CREATE TABLE [dbo].[ForumTopicUserBookmark] (
    [Id]           INT IDENTITY (1, 1) NOT NULL,
    [ForumTopicId] INT NOT NULL,
    [UserId]       INT NOT NULL,
    CONSTRAINT [PK_ForumTopicUserBookmark] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ForumTopicUserBookmark_ForumTopic] FOREIGN KEY ([ForumTopicId]) REFERENCES [dbo].[ForumTopic] ([Id]),
    CONSTRAINT [FK_ForumTopicUserBookmark_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

