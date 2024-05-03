CREATE TABLE [dbo].[MemorabiliaFootball] (
    [Id]             INT IDENTITY (1, 1) NOT NULL,
    [MemorabiliaId]  INT NOT NULL,
    [FootballTypeId] INT NOT NULL,
    CONSTRAINT [PK_MemorabiliaFootball] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MemorabiliaFootball_FootballType] FOREIGN KEY ([FootballTypeId]) REFERENCES [dbo].[FootballType] ([Id]),
    CONSTRAINT [FK_MemorabiliaFootball_Memorabilia] FOREIGN KEY ([MemorabiliaId]) REFERENCES [dbo].[Memorabilia] ([Id])
);

