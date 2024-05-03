CREATE TABLE [dbo].[Conference] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [SportLeagueLevelId] INT            NOT NULL,
    [Name]               NVARCHAR (100) NOT NULL,
    [Abbreviation]       NVARCHAR (10)  NULL,
    [ImageFileName]      NVARCHAR (100) NULL,
    CONSTRAINT [PK_Conference] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Conference_SportLeagueLevel] FOREIGN KEY ([SportLeagueLevelId]) REFERENCES [dbo].[SportLeagueLevel] ([Id])
);

