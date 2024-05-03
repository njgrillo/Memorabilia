CREATE TABLE [dbo].[LeaderType] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (200) NOT NULL,
    [Abbreviation] VARCHAR (25)  NULL,
    CONSTRAINT [PK_LeaderType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

