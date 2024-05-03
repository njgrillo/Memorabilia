CREATE TABLE [dbo].[CareerRecord] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [PersonId]     INT           NOT NULL,
    [RecordTypeId] INT           NOT NULL,
    [Record]       VARCHAR (100) NULL,
    CONSTRAINT [PK_CareerRecord] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CareerRecord_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id]),
    CONSTRAINT [FK_CareerRecord_RecordType] FOREIGN KEY ([RecordTypeId]) REFERENCES [dbo].[RecordType] ([Id])
);

