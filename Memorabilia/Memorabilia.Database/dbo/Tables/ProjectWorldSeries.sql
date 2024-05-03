CREATE TABLE [dbo].[ProjectWorldSeries] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [ProjectId]  INT NOT NULL,
    [TeamId]     INT NOT NULL,
    [Year]       INT NULL,
    [ItemTypeId] INT NULL,
    CONSTRAINT [PK_ProjectWorldSeries] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProjectWorldSeries_ItemType] FOREIGN KEY ([ItemTypeId]) REFERENCES [dbo].[ItemType] ([Id]),
    CONSTRAINT [FK_ProjectWorldSeries_Project] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Project] ([Id]),
    CONSTRAINT [FK_ProjectWorldSeries_Team] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Team] ([Id])
);

