CREATE TABLE [dbo].[Commissioner] (
    [Id]                 INT IDENTITY (1, 1) NOT NULL,
    [PersonId]           INT NOT NULL,
    [SportLeagueLevelId] INT NOT NULL,
    [BeginYear]          INT NULL,
    [EndYear]            INT NULL,
    CONSTRAINT [PK_Commissioner] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Commissioner_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id]),
    CONSTRAINT [FK_Commissioner_SportLeagueLevel] FOREIGN KEY ([SportLeagueLevelId]) REFERENCES [dbo].[SportLeagueLevel] ([Id])
);

