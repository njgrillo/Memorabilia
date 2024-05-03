CREATE TABLE [dbo].[MemorabiliaBat] (
    [Id]            INT IDENTITY (1, 1) NOT NULL,
    [MemorabiliaId] INT NOT NULL,
    [BatTypeId]     INT NULL,
    [Length]        INT NULL,
    [ColorId]       INT NULL,
    CONSTRAINT [PK_MemorabiliaBat] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MemorabiliaBat_BatType] FOREIGN KEY ([BatTypeId]) REFERENCES [dbo].[BatType] ([Id]),
    CONSTRAINT [FK_MemorabiliaBat_Color] FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Color] ([Id]),
    CONSTRAINT [FK_MemorabiliaBat_Memorabilia] FOREIGN KEY ([MemorabiliaId]) REFERENCES [dbo].[Memorabilia] ([Id])
);

