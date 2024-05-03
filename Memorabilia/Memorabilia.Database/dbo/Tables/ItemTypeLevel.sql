CREATE TABLE [dbo].[ItemTypeLevel] (
    [Id]          INT IDENTITY (1, 1) NOT NULL,
    [ItemTypeId]  INT NOT NULL,
    [LevelTypeId] INT NOT NULL,
    CONSTRAINT [PK_ItemTypeLevel] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ItemTypeLevel_ItemType] FOREIGN KEY ([ItemTypeId]) REFERENCES [dbo].[ItemType] ([Id]),
    CONSTRAINT [FK_ItemTypeLevel_LevelType] FOREIGN KEY ([LevelTypeId]) REFERENCES [dbo].[LevelType] ([Id])
);

