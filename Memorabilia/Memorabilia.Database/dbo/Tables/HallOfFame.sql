CREATE TABLE [dbo].[HallOfFame] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [PersonId]           INT            NOT NULL,
    [SportLeagueLevelId] INT            NOT NULL,
    [InductionYear]      INT            NULL,
    [VotePercentage]     DECIMAL (5, 2) NULL,
    [BallotNumber]       INT            NULL,
    CONSTRAINT [PK_HallOfFame] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_HallOfFame_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id]),
    CONSTRAINT [FK_HallOfFame_SportLeagueLevel] FOREIGN KEY ([SportLeagueLevelId]) REFERENCES [dbo].[SportLeagueLevel] ([Id])
);

