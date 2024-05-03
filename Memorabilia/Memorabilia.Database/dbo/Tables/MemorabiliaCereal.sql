CREATE TABLE [dbo].[MemorabiliaCereal] (
    [Id]            INT IDENTITY (1, 1) NOT NULL,
    [MemorabiliaId] INT NOT NULL,
    [CerealTypeId]  INT NOT NULL,
    CONSTRAINT [PK_MemorabiliaCereal] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MemorabiliaCereal_CerealType] FOREIGN KEY ([CerealTypeId]) REFERENCES [dbo].[CerealType] ([Id]),
    CONSTRAINT [FK_MemorabiliaCereal_Memorabilia] FOREIGN KEY ([MemorabiliaId]) REFERENCES [dbo].[Memorabilia] ([Id])
);

