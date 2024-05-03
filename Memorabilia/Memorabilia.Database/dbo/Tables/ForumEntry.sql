CREATE TABLE [dbo].[ForumEntry] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [ForumTopicId]    INT            NOT NULL,
    [Message]         NVARCHAR (MAX) NOT NULL,
    [Rank]            INT            NOT NULL,
    [CreatedDate]     DATETIME       NOT NULL,
    [CreatedByUserId] INT            NOT NULL,
    [ModifiedDate]    DATETIME       NULL,
    CONSTRAINT [PK_ForumEntry] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ForumEntry_CreatedByUser] FOREIGN KEY ([CreatedByUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_ForumEntry_ForumTopic] FOREIGN KEY ([ForumTopicId]) REFERENCES [dbo].[ForumTopic] ([Id])
);

