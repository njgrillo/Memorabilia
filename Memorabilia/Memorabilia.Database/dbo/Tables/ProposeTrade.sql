CREATE TABLE [dbo].[ProposeTrade] (
    [Id]                          INT             IDENTITY (1, 1) NOT NULL,
    [TradeCreatorUserId]          INT             NOT NULL,
    [TradePartnerUserId]          INT             NOT NULL,
    [ProposedDate]                DATETIME        NOT NULL,
    [ExpirationDate]              DATETIME        NOT NULL,
    [ProposeTradeStatusTypeId]    INT             NOT NULL,
    [AmountTradeCreatorToReceive] DECIMAL (12, 2) NULL,
    [AmountTradeCreatorToSend]    DECIMAL (12, 2) NULL,
    CONSTRAINT [PK_ProposeTrade] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProposeTrade_ProposeTradeStatusType] FOREIGN KEY ([ProposeTradeStatusTypeId]) REFERENCES [dbo].[ProposeTradeStatusType] ([Id]),
    CONSTRAINT [FK_ProposeTrade_TradeCreatorUser] FOREIGN KEY ([TradeCreatorUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_ProposeTrade_TradePartnerUser] FOREIGN KEY ([TradePartnerUserId]) REFERENCES [dbo].[User] ([Id])
);

