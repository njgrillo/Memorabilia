CREATE TABLE [dbo].[UserMessageReply] (
    [Id]                  INT            IDENTITY (1, 1) NOT NULL,
    [UserMessageId]       INT            NOT NULL,
    [Message]             NVARCHAR (MAX) NOT NULL,
    [UserMessageStatusId] INT            NOT NULL,
    [SenderUserId]        INT            NOT NULL,
    [ReceiverUserId]      INT            NOT NULL,
    [CreatedDate]         DATETIME       NOT NULL,
    [CreatedByUserId]     INT            NOT NULL,
    CONSTRAINT [PK_UserMessageReply] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserMessageReply_ReceiverUser] FOREIGN KEY ([ReceiverUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_UserMessageReply_SenderUser] FOREIGN KEY ([SenderUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_UserMessageReply_User] FOREIGN KEY ([CreatedByUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_UserMessageReply_UserMessage] FOREIGN KEY ([UserMessageId]) REFERENCES [dbo].[UserMessage] ([Id]),
    CONSTRAINT [FK_UserMessageReply_UserMessageStatus] FOREIGN KEY ([UserMessageStatusId]) REFERENCES [dbo].[UserMessageStatus] ([Id])
);

