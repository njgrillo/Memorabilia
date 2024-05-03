CREATE TABLE [dbo].[MemorabiliaTeam] (
    [Id]            INT IDENTITY (1, 1) NOT NULL,
    [MemorabiliaId] INT NOT NULL,
    [TeamId]        INT NOT NULL,
    CONSTRAINT [PK_MemorabiliaTeam] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MemorabiliaTeam_Memorabilia] FOREIGN KEY ([MemorabiliaId]) REFERENCES [dbo].[Memorabilia] ([Id]),
    CONSTRAINT [FK_MemorabiliaTeam_Team] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Team] ([Id])
);

