CREATE TABLE [dbo].[MemorabiliaGlove] (
    [Id]            INT      IDENTITY (1, 1) NOT NULL,
    [MemorabiliaId] INT      NOT NULL,
    [GloveTypeId]   INT      NOT NULL,
    [GameDate]      DATETIME NULL,
    CONSTRAINT [PK_MemorabiliaGlove] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MemorabiliaGame_GloveType] FOREIGN KEY ([GloveTypeId]) REFERENCES [dbo].[GloveType] ([Id]),
    CONSTRAINT [FK_MemorabiliaGlove_Memorabilia] FOREIGN KEY ([MemorabiliaId]) REFERENCES [dbo].[Memorabilia] ([Id])
);

