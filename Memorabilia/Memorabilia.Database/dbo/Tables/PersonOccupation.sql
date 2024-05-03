CREATE TABLE [dbo].[PersonOccupation] (
    [Id]               INT IDENTITY (1, 1) NOT NULL,
    [PersonId]         INT NOT NULL,
    [OccupationId]     INT NOT NULL,
    [OccupationTypeId] INT NOT NULL,
    CONSTRAINT [PK_PersonOccupation] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PersonOccupation_Occupation] FOREIGN KEY ([OccupationId]) REFERENCES [dbo].[Occupation] ([Id]),
    CONSTRAINT [FK_PersonOccupation_OccupationType] FOREIGN KEY ([OccupationTypeId]) REFERENCES [dbo].[OccupationType] ([Id]),
    CONSTRAINT [FK_PersonOccupation_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id])
);

