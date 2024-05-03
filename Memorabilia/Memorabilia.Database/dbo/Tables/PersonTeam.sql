CREATE TABLE [dbo].[PersonTeam] (
    [Id]             INT IDENTITY (1, 1) NOT NULL,
    [PersonId]       INT NOT NULL,
    [TeamId]         INT NOT NULL,
    [BeginYear]      INT NULL,
    [EndYear]        INT NULL,
    [TeamRoleTypeId] INT NOT NULL,
    CONSTRAINT [PK_PersonTeam] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PersonTeam_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id]),
    CONSTRAINT [FK_PersonTeam_Team] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Team] ([Id]),
    CONSTRAINT [FK_PersonTeam_TeamRoleType] FOREIGN KEY ([TeamRoleTypeId]) REFERENCES [dbo].[TeamRoleType] ([Id])
);

