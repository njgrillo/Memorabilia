CREATE TABLE [dbo].[ProposeTradeMemorabiliaType] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (100) NOT NULL,
    [Abbreviation] VARCHAR (10)  NULL,
    CONSTRAINT [PK_ProposeTradeMemorabiliaType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

