CREATE TABLE [dbo].[League] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [SportLeagueLevelId] INT            NOT NULL,
    [Name]               NVARCHAR (100) NOT NULL,
    [Abbreviation]       NVARCHAR (10)  NULL,
    [ImagePath]          VARCHAR (200)  NULL,
    CONSTRAINT [PK_League] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_League_SportLeagueLevel] FOREIGN KEY ([SportLeagueLevelId]) REFERENCES [dbo].[SportLeagueLevel] ([Id])
);

