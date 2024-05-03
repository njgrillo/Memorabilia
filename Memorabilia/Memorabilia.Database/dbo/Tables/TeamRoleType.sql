CREATE TABLE [dbo].[TeamRoleType] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (100) NOT NULL,
    [Abbreviation] VARCHAR (25)  NULL,
    CONSTRAINT [PK_TeamRoleType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

