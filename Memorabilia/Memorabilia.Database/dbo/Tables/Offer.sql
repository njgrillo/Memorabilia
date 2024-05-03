CREATE TABLE [dbo].[Offer] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [OfferDate]         DATETIME        NOT NULL,
    [Amount]            DECIMAL (12, 2) NOT NULL,
    [MemorabiliaId]     INT             NOT NULL,
    [BuyerUserId]       INT             NOT NULL,
    [SellerUserId]      INT             NOT NULL,
    [ExpirationDate]    DATETIME        NOT NULL,
    [OfferStatusTypeId] INT             NOT NULL,
    CONSTRAINT [PK_Offer] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Offer_BuyerUser] FOREIGN KEY ([BuyerUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_Offer_Memorabilia] FOREIGN KEY ([MemorabiliaId]) REFERENCES [dbo].[Memorabilia] ([Id]),
    CONSTRAINT [FK_Offer_OfferStatusType] FOREIGN KEY ([OfferStatusTypeId]) REFERENCES [dbo].[OfferStatusType] ([Id]),
    CONSTRAINT [FK_Offer_SellerUser] FOREIGN KEY ([SellerUserId]) REFERENCES [dbo].[User] ([Id])
);

