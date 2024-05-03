CREATE TABLE [dbo].[SingleSeasonRecord] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [PersonId]     INT           NOT NULL,
    [RecordTypeId] INT           NOT NULL,
    [Year]         INT           NOT NULL,
    [Record]       VARCHAR (100) NULL,
    CONSTRAINT [PK_SingleSeasonRecord] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SingleSeasonRecord_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id]),
    CONSTRAINT [FK_SingleSeasonRecord_RecordType] FOREIGN KEY ([RecordTypeId]) REFERENCES [dbo].[RecordType] ([Id])
);

