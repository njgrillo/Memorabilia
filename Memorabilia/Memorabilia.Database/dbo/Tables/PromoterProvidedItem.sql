CREATE TABLE [dbo].[PromoterProvidedItem] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [PromoterId]   INT             NOT NULL,
    [ItemTypeId]   INT             NOT NULL,
    [Cost]         DECIMAL (12, 2) NOT NULL,
    [ShippingCost] DECIMAL (12, 2) NULL,
    CONSTRAINT [PK_PromoterProvidedItem] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PromoterProvidedItem_ItemType] FOREIGN KEY ([ItemTypeId]) REFERENCES [dbo].[ItemType] ([Id]),
    CONSTRAINT [FK_PromoterProvidedItem_Promoter] FOREIGN KEY ([PromoterId]) REFERENCES [dbo].[User] ([Id])
);

