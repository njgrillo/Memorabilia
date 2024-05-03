CREATE TABLE [dbo].[SportLeagueLevel] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [SportId]      INT            NOT NULL,
    [LevelTypeId]  INT            NOT NULL,
    [Name]         NVARCHAR (100) NOT NULL,
    [Abbreviation] NVARCHAR (10)  NULL,
    CONSTRAINT [PK_SportLeagueLevel] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SportLeagueLevel_LevelType] FOREIGN KEY ([LevelTypeId]) REFERENCES [dbo].[LevelType] ([Id]),
    CONSTRAINT [FK_SportLeagueLevel_Sport] FOREIGN KEY ([SportId]) REFERENCES [dbo].[Sport] ([Id])
);

