CREATE TABLE [dbo].[College] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (300) NOT NULL,
    [Abbreviation] VARCHAR (20)  NULL,
    CONSTRAINT [PK_College] PRIMARY KEY CLUSTERED ([Id] ASC)
);

