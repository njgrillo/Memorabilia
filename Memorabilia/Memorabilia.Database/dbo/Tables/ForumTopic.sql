CREATE TABLE [dbo].[ForumTopic] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [ForumCategoryId] INT            NOT NULL,
    [Subject]         NVARCHAR (300) NOT NULL,
    [CreatedDate]     DATETIME       NOT NULL,
    [CreatedByUserId] INT            NOT NULL,
    [ModifiedDate]    DATETIME       NULL,
    [SportId]         INT            NULL,
    CONSTRAINT [PK_ForumTopic] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ForumTopic_CreatedByUser] FOREIGN KEY ([CreatedByUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_ForumTopic_ForumCategory] FOREIGN KEY ([ForumCategoryId]) REFERENCES [dbo].[ForumCategory] ([Id]),
    CONSTRAINT [FK_ForumTopic_Sport] FOREIGN KEY ([SportId]) REFERENCES [dbo].[Sport] ([Id])
);

