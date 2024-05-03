CREATE TABLE [dbo].[HelmetQualityType] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (100) NOT NULL,
    [Abbreviation] VARCHAR (10)  NULL,
    CONSTRAINT [PK_HelmetQualityType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

