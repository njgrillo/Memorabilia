CREATE TABLE [dbo].[UserMessageReplyImage] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [UserMessageReplyId] INT            NOT NULL,
    [FileName]           NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_UserMessageReplyImage] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserMessageReplyImage_UserMessageReply] FOREIGN KEY ([UserMessageReplyId]) REFERENCES [dbo].[UserMessageReply] ([Id])
);

