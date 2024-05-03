CREATE TABLE [dbo].[AllStar] (
    [Id]                 INT IDENTITY (1, 1) NOT NULL,
    [PersonId]           INT NOT NULL,
    [Year]               INT NOT NULL,
    [SportId]            INT NOT NULL,
    [SportLeagueLevelId] INT NULL,
    CONSTRAINT [PK_AllStar] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AllStar_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id]),
    CONSTRAINT [FK_AllStar_Sport] FOREIGN KEY ([SportId]) REFERENCES [dbo].[Sport] ([Id]),
    CONSTRAINT [FK_AllStar_SportLeagueLevel] FOREIGN KEY ([SportLeagueLevelId]) REFERENCES [dbo].[SportLeagueLevel] ([Id])
);

