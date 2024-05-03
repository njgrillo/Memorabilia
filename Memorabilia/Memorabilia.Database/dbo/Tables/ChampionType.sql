CREATE TABLE [dbo].[ChampionType] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (200) NOT NULL,
    [Abbreviation] VARCHAR (25)  NULL,
    CONSTRAINT [PK_ChampionType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

