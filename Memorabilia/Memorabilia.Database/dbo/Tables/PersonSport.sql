CREATE TABLE [dbo].[PersonSport] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [PersonId]  INT NOT NULL,
    [SportId]   INT NOT NULL,
    [IsPrimary] BIT NOT NULL,
    CONSTRAINT [PK_PersonSport] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PersonSport_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id]),
    CONSTRAINT [FK_PersonTeam_Sport] FOREIGN KEY ([SportId]) REFERENCES [dbo].[Sport] ([Id])
);

