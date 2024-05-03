CREATE TABLE [dbo].[MemorabiliaLevelType] (
    [Id]            INT IDENTITY (1, 1) NOT NULL,
    [MemorabiliaId] INT NOT NULL,
    [LevelTypeId]   INT NOT NULL,
    CONSTRAINT [PK_MemorabiliaLevelType] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MemorabiliaLevelType_LevelType] FOREIGN KEY ([LevelTypeId]) REFERENCES [dbo].[LevelType] ([Id]),
    CONSTRAINT [FK_MemorabiliaLevelType_Memorabilia] FOREIGN KEY ([MemorabiliaId]) REFERENCES [dbo].[Memorabilia] ([Id])
);

