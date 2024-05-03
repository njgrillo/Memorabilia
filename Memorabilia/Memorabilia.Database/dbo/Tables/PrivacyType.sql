CREATE TABLE [dbo].[PrivacyType] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (75) NOT NULL,
    [Abbreviation] VARCHAR (10) NULL,
    CONSTRAINT [PK_PrivacyType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

