CREATE TABLE [dbo].[PhotoType] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (50) NOT NULL,
    [Abbreviation] NVARCHAR (10) NULL,
    CONSTRAINT [PK_PhotoType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

