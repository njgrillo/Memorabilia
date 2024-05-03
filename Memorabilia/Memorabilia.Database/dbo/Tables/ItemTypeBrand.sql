CREATE TABLE [dbo].[ItemTypeBrand] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [ItemTypeId] INT NOT NULL,
    [BrandId]    INT NOT NULL,
    CONSTRAINT [PK_ItemTypeBrand] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ItemTypeBrand_Brand] FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brand] ([Id]),
    CONSTRAINT [FK_ItemTypeBrand_ItemType] FOREIGN KEY ([ItemTypeId]) REFERENCES [dbo].[ItemType] ([Id])
);

