CREATE TABLE [dbo].[TempSingleSeasonRecord] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [PersonId]     INT             NOT NULL,
    [RecordTypeId] INT             NOT NULL,
    [Year]         INT             NOT NULL,
    [Amount]       DECIMAL (12, 3) NULL
);

