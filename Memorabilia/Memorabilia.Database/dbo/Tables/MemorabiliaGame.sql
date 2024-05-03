CREATE TABLE [dbo].[MemorabiliaGame] (
    [Id]              INT      IDENTITY (1, 1) NOT NULL,
    [MemorabiliaId]   INT      NOT NULL,
    [GameStyleTypeId] INT      NOT NULL,
    [PersonId]        INT      NULL,
    [GameDate]        DATETIME NULL,
    CONSTRAINT [PK_MemorabiliaGame] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MemorabiliaGame_GameStyleType] FOREIGN KEY ([GameStyleTypeId]) REFERENCES [dbo].[GameStyleType] ([Id]),
    CONSTRAINT [FK_MemorabiliaGame_Memorabilia] FOREIGN KEY ([MemorabiliaId]) REFERENCES [dbo].[Memorabilia] ([Id]),
    CONSTRAINT [FK_MemorabiliaGame_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id])
);

