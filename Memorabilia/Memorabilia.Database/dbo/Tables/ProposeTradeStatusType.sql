CREATE TABLE [dbo].[ProposeTradeStatusType] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (100) NOT NULL,
    [Abbreviation] VARCHAR (10)  NULL,
    CONSTRAINT [PK_ProposeTradeStatusType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

