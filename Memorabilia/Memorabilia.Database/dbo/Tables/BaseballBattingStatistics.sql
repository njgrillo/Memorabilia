CREATE TABLE [dbo].[BaseballBattingStatistics] (
    [Id]           INT IDENTITY (1, 1) NOT NULL,
    [PersonId]     INT NOT NULL,
    [Year]         INT NOT NULL,
    [AtBats]       INT NULL,
    [Hits]         INT NULL,
    [Walks]        INT NULL,
    [Singles]      INT NULL,
    [Doubles]      INT NULL,
    [Triples]      INT NULL,
    [Homeruns]     INT NULL,
    [RunsBattedIn] INT NULL,
    [Runs]         INT NULL,
    [Strikeouts]   INT NULL,
    CONSTRAINT [PK_BaseballBattingStatistics] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BaseballBattingStatistics_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id])
);

