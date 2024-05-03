CREATE TABLE [dbo].[TeamConference] (
    [Id]           INT IDENTITY (1, 1) NOT NULL,
    [TeamId]       INT NOT NULL,
    [ConferenceId] INT NOT NULL,
    [BeginYear]    INT NULL,
    [EndYear]      INT NULL,
    CONSTRAINT [PK_TeamConference] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TeamConference_Conference] FOREIGN KEY ([ConferenceId]) REFERENCES [dbo].[Conference] ([Id]),
    CONSTRAINT [FK_TeamConference_Team] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Team] ([Id])
);

