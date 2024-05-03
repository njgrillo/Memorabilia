CREATE TABLE [dbo].[UserMessage] (
    [Id]                  INT            IDENTITY (1, 1) NOT NULL,
    [Subject]             NVARCHAR (300) NOT NULL,
    [UserMessageStatusId] INT            NOT NULL,
    CONSTRAINT [PK_UserMessage] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserMessage_UserMessageStatus] FOREIGN KEY ([UserMessageStatusId]) REFERENCES [dbo].[UserMessageStatus] ([Id])
);

