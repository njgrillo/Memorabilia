CREATE TABLE [dbo].[ItemTypeSize] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [ItemTypeId] INT NOT NULL,
    [SizeId]     INT NOT NULL,
    CONSTRAINT [PK_ItemTypeSize] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ItemTypeSize_ItemType] FOREIGN KEY ([ItemTypeId]) REFERENCES [dbo].[ItemType] ([Id]),
    CONSTRAINT [FK_ItemTypeSize_Size] FOREIGN KEY ([SizeId]) REFERENCES [dbo].[Size] ([Id])
);

