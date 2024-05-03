CREATE TABLE [dbo].[FigureType] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (100) NOT NULL,
    [Abbreviation] VARCHAR (10)  NULL,
    CONSTRAINT [PK_FigureType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

