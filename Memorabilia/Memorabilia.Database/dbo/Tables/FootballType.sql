CREATE TABLE [dbo].[FootballType] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (100) NOT NULL,
    [Abbreviation] VARCHAR (10)  NULL,
    CONSTRAINT [PK_FootballType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

