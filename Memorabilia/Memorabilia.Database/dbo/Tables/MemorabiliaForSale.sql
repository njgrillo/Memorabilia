CREATE TABLE [dbo].[MemorabiliaForSale] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [MemorabiliaId]     INT             NOT NULL,
    [BuyNowPrice]       DECIMAL (12, 2) NULL,
    [AllowBestOffer]    BIT             NOT NULL,
    [MinimumOfferPrice] DECIMAL (12, 2) NULL,
    CONSTRAINT [PK_MemorabiliaForSale] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MemorabiliaForSale_Memorabilia] FOREIGN KEY ([MemorabiliaId]) REFERENCES [dbo].[Memorabilia] ([Id])
);

