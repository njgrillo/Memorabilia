CREATE TABLE [dbo].[MemorabiliaTransactionTrade] (
    [Id]                       INT             IDENTITY (1, 1) NOT NULL,
    [MemorabiliaTransactionId] INT             NOT NULL,
    [MemorabiliaId]            INT             NOT NULL,
    [TransactionTradeTypeId]   INT             NOT NULL,
    [CashIncludedAmount]       DECIMAL (12, 2) NULL,
    [CashIncludedTypeId]       INT             NULL,
    CONSTRAINT [PK_MemorabiliaTransactionTrade] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MemorabiliaTransactionTrade_CashIncludedType] FOREIGN KEY ([CashIncludedTypeId]) REFERENCES [dbo].[TransactionTradeType] ([Id]),
    CONSTRAINT [FK_MemorabiliaTransactionTrade_Memorabilia] FOREIGN KEY ([MemorabiliaId]) REFERENCES [dbo].[Memorabilia] ([Id]),
    CONSTRAINT [FK_MemorabiliaTransactionTrade_MemorabiliaTransactionTrade] FOREIGN KEY ([MemorabiliaTransactionId]) REFERENCES [dbo].[MemorabiliaTransaction] ([Id]),
    CONSTRAINT [FK_MemorabiliaTransactionTrade_TransactionTradeType] FOREIGN KEY ([TransactionTradeTypeId]) REFERENCES [dbo].[TransactionTradeType] ([Id])
);

