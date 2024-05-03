CREATE TABLE [dbo].[ItemTypeSport] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [ItemTypeId] INT NOT NULL,
    [SportId]    INT NOT NULL,
    CONSTRAINT [PK_ItemTypeSport] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ItemTypeSport_ItemType] FOREIGN KEY ([ItemTypeId]) REFERENCES [dbo].[ItemType] ([Id]),
    CONSTRAINT [FK_ItemTypeSport_Sport] FOREIGN KEY ([SportId]) REFERENCES [dbo].[Sport] ([Id])
);

