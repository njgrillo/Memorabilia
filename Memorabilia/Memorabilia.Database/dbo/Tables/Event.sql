CREATE TABLE [dbo].[Event] (
    [Id]                INT      IDENTITY (1, 1) NOT NULL,
    [AcquisitionTypeId] INT      NOT NULL,
    [EventDate]         DATETIME NULL,
    CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Event_AcquisitionType] FOREIGN KEY ([AcquisitionTypeId]) REFERENCES [dbo].[AcquisitionType] ([Id])
);

