CREATE TABLE [dbo].[TeamLeague] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [TeamId]    INT NOT NULL,
    [LeagueId]  INT NOT NULL,
    [BeginYear] INT NULL,
    [EndYear]   INT NULL,
    CONSTRAINT [PK_TeamLeague] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TeamLeague_League] FOREIGN KEY ([LeagueId]) REFERENCES [dbo].[League] ([Id]),
    CONSTRAINT [FK_TeamLeague_Team] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Team] ([Id])
);

