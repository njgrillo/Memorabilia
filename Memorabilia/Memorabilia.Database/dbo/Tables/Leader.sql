CREATE TABLE [dbo].[Leader] (
    [Id]           INT IDENTITY (1, 1) NOT NULL,
    [PersonId]     INT NOT NULL,
    [LeaderTypeId] INT NOT NULL,
    [Year]         INT NOT NULL,
    CONSTRAINT [PK_Leader] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Leader_LeaderType] FOREIGN KEY ([LeaderTypeId]) REFERENCES [dbo].[LeaderType] ([Id]),
    CONSTRAINT [FK_Leader_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id])
);

