CREATE TABLE [dbo].[AllStarDetail] (
    [Id]                 INT IDENTITY (1, 1) NOT NULL,
    [SportLeagueLevelId] INT NOT NULL,
    [Year]               INT NOT NULL,
    [NumberOfAllStars]   INT NOT NULL,
    [MonthPlayed]        INT NOT NULL,
    CONSTRAINT [PK_AllStarDetail] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AllStarDetail_SportLeagueLevel] FOREIGN KEY ([SportLeagueLevelId]) REFERENCES [dbo].[SportLeagueLevel] ([Id])
);

