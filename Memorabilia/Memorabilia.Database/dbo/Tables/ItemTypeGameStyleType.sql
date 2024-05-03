CREATE TABLE [dbo].[ItemTypeGameStyleType] (
    [Id]              INT IDENTITY (1, 1) NOT NULL,
    [ItemTypeId]      INT NOT NULL,
    [GameStyleTypeId] INT NOT NULL,
    CONSTRAINT [PK_ItemTypeGameStyleType] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ItemTypeGameStyleType_GameStyleType] FOREIGN KEY ([GameStyleTypeId]) REFERENCES [dbo].[GameStyleType] ([Id]),
    CONSTRAINT [FK_ItemTypeGameStyleType_ItemType] FOREIGN KEY ([ItemTypeId]) REFERENCES [dbo].[ItemType] ([Id])
);

