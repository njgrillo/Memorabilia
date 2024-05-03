CREATE TABLE [dbo].[PrivateSigningPromoterProvidedItem] (
    [Id]                     INT IDENTITY (1, 1) NOT NULL,
    [PrivateSigningId]       INT NOT NULL,
    [PromoterProvidedItemId] INT NOT NULL,
    CONSTRAINT [PK_PrivateSigningPromoterProvidedItem] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PrivateSigningPromoterProvidedItem_PrivateSigning] FOREIGN KEY ([PrivateSigningId]) REFERENCES [dbo].[PrivateSigning] ([Id]),
    CONSTRAINT [FK_PrivateSigningPromoterProvidedItem_PromoterProvidedItem] FOREIGN KEY ([PromoterProvidedItemId]) REFERENCES [dbo].[PromoterProvidedItem] ([Id])
);

