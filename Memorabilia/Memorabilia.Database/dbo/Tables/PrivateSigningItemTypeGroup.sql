CREATE TABLE [dbo].[PrivateSigningItemTypeGroup] (
    [Id]                        INT             IDENTITY (1, 1) NOT NULL,
    [PrivateSigningItemGroupId] INT             NOT NULL,
    [Cost]                      DECIMAL (12, 2) NOT NULL,
    [ShippingCost]              DECIMAL (12, 2) NULL,
    CONSTRAINT [PK_PrivateSigningItemTypeGroup] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PrivateSigningItemTypeGroup_PrivateSigningItemGroup] FOREIGN KEY ([PrivateSigningItemGroupId]) REFERENCES [dbo].[PrivateSigningItemGroup] ([Id])
);

