CREATE TABLE [dbo].[TransactionTradeType] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (100) NOT NULL,
    [Abbreviation] VARCHAR (25)  NULL,
    CONSTRAINT [PK_TransactionTradeType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

