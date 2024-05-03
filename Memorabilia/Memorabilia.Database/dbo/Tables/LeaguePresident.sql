CREATE TABLE [dbo].[LeaguePresident] (
    [Id]                 INT IDENTITY (1, 1) NOT NULL,
    [PersonId]           INT NOT NULL,
    [SportLeagueLevelId] INT NOT NULL,
    [LeagueId]           INT NOT NULL,
    [BeginYear]          INT NULL,
    [EndYear]            INT NULL,
    CONSTRAINT [PK_LeaguePresident] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_LeaguePresident_League] FOREIGN KEY ([LeagueId]) REFERENCES [dbo].[League] ([Id]),
    CONSTRAINT [FK_LeaguePresident_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id]),
    CONSTRAINT [FK_LeaguePresident_SportLeagueLevel] FOREIGN KEY ([SportLeagueLevelId]) REFERENCES [dbo].[SportLeagueLevel] ([Id])
);

