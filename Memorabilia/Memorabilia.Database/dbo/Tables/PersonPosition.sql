CREATE TABLE [dbo].[PersonPosition] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [PersonId]   INT NOT NULL,
    [PositionId] INT NOT NULL,
    [IsPrimary]  BIT NOT NULL,
    CONSTRAINT [PK_PersonPosition] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PersonPosition_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id]),
    CONSTRAINT [FK_PersonPosition_Position] FOREIGN KEY ([PositionId]) REFERENCES [dbo].[Position] ([Id])
);

