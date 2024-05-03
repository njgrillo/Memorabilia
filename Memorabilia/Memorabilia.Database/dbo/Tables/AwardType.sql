CREATE TABLE [dbo].[AwardType] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (200) NOT NULL,
    [Abbreviation] VARCHAR (30)  NULL,
    CONSTRAINT [PK_AwardType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

