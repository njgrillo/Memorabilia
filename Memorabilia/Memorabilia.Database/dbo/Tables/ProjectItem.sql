CREATE TABLE [dbo].[ProjectItem] (
    [Id]              INT IDENTITY (1, 1) NOT NULL,
    [ProjectId]       INT NOT NULL,
    [ItemTypeId]      INT NOT NULL,
    [MultiSignedItem] BIT NOT NULL,
    CONSTRAINT [PK_ProjectItem] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProjectItem_ItemType] FOREIGN KEY ([ItemTypeId]) REFERENCES [dbo].[ItemType] ([Id]),
    CONSTRAINT [FK_ProjectItem_Project] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Project] ([Id])
);

