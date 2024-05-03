CREATE TABLE [dbo].[ProposeTradeMemorabilia] (
    [Id]             INT IDENTITY (1, 1) NOT NULL,
    [ProposeTradeId] INT NOT NULL,
    [MemorabiliaId]  INT NOT NULL,
    [UserId]         INT NOT NULL,
    CONSTRAINT [PK_ProposeTradeMemorabilia] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProposeTradeMemorabilia_Memorabilia] FOREIGN KEY ([MemorabiliaId]) REFERENCES [dbo].[Memorabilia] ([Id]),
    CONSTRAINT [FK_ProposeTradeMemorabilia_ProposeTrade] FOREIGN KEY ([ProposeTradeId]) REFERENCES [dbo].[ProposeTrade] ([Id]),
    CONSTRAINT [FK_ProposeTradeMemorabilia_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

