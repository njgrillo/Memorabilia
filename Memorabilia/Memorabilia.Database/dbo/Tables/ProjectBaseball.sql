CREATE TABLE [dbo].[ProjectBaseball] (
    [Id]             INT IDENTITY (1, 1) NOT NULL,
    [ProjectId]      INT NOT NULL,
    [BaseballTypeId] INT NOT NULL,
    [Year]           INT NULL,
    [TeamId]         INT NULL,
    CONSTRAINT [PK_ProjectBaseball] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProjectBaseball_BaseballType] FOREIGN KEY ([BaseballTypeId]) REFERENCES [dbo].[BaseballType] ([Id]),
    CONSTRAINT [FK_ProjectBaseball_Project] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Project] ([Id]),
    CONSTRAINT [FK_ProjectBaseball_Team] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Team] ([Id])
);

