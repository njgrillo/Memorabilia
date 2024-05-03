CREATE TABLE [dbo].[ProjectTeam] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [ProjectId] INT NOT NULL,
    [TeamId]    INT NOT NULL,
    [Year]      INT NULL,
    CONSTRAINT [PK_ProjectTeam] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProjectTeam_Project] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Project] ([Id]),
    CONSTRAINT [FK_ProjectTeam_Team] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Team] ([Id])
);

