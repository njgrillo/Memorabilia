CREATE TABLE [dbo].[MemorabiliaTransactionSale] (
    [Id]                       INT             IDENTITY (1, 1) NOT NULL,
    [MemorabiliaTransactionId] INT             NOT NULL,
    [MemorabiliaId]            INT             NOT NULL,
    [SaleAmount]               DECIMAL (12, 2) NOT NULL,
    CONSTRAINT [PK_MemorabiliaTransactionSale] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MemorabiliaTransactionSale_Memorabilia] FOREIGN KEY ([MemorabiliaId]) REFERENCES [dbo].[Memorabilia] ([Id]),
    CONSTRAINT [FK_MemorabiliaTransactionSale_MemorabiliaTransactionSale] FOREIGN KEY ([MemorabiliaTransactionId]) REFERENCES [dbo].[MemorabiliaTransaction] ([Id])
);

