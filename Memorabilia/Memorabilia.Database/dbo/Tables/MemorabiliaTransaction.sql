CREATE TABLE [dbo].[MemorabiliaTransaction] (
    [Id]                INT      IDENTITY (1, 1) NOT NULL,
    [TransactionTypeId] INT      NOT NULL,
    [TransactionDate]   DATETIME NULL,
    [UserId]            INT      NOT NULL,
    CONSTRAINT [PK_MemorabiliaTransaction] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MemorabiliaTransaction_TransactionType] FOREIGN KEY ([TransactionTypeId]) REFERENCES [dbo].[TransactionType] ([Id]),
    CONSTRAINT [FK_MemorabiliaTransaction_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

