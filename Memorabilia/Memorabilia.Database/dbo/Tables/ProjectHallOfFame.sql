CREATE TABLE [dbo].[ProjectHallOfFame] (
    [Id]                 INT IDENTITY (1, 1) NOT NULL,
    [ProjectId]          INT NOT NULL,
    [SportLeagueLevelId] INT NOT NULL,
    [Year]               INT NULL,
    [ItemTypeId]         INT NULL,
    CONSTRAINT [PK_ProjectHallOfFame] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProjectHallOfFame_ItemType] FOREIGN KEY ([ItemTypeId]) REFERENCES [dbo].[ItemType] ([Id]),
    CONSTRAINT [FK_ProjectHallOfFame_Project] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Project] ([Id]),
    CONSTRAINT [FK_ProjectHallOfFame_SportLeagueLevel] FOREIGN KEY ([SportLeagueLevelId]) REFERENCES [dbo].[SportLeagueLevel] ([Id])
);

