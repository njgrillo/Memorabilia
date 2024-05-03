CREATE TABLE [dbo].[ItemTypeSpot] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [ItemTypeId] INT NOT NULL,
    [SpotId]     INT NOT NULL,
    CONSTRAINT [PK_ItemTypeSpot] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ItemTypeSpot_ItemType] FOREIGN KEY ([ItemTypeId]) REFERENCES [dbo].[ItemType] ([Id]),
    CONSTRAINT [FK_ItemTypeSpot_Spot] FOREIGN KEY ([SpotId]) REFERENCES [dbo].[Spot] ([Id])
);

