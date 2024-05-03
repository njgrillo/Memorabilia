CREATE TABLE [dbo].[TeamDivision] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [TeamId]     INT NOT NULL,
    [DivisionId] INT NOT NULL,
    [BeginYear]  INT NULL,
    [EndYear]    INT NULL,
    CONSTRAINT [PK_TeamDivision] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TeamDivision_Division] FOREIGN KEY ([DivisionId]) REFERENCES [dbo].[Division] ([Id]),
    CONSTRAINT [FK_TeamDivision_Team] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Team] ([Id])
);

