CREATE TABLE [dbo].[MemorabiliaPerson] (
    [Id]            INT IDENTITY (1, 1) NOT NULL,
    [MemorabiliaId] INT NOT NULL,
    [PersonId]      INT NOT NULL,
    CONSTRAINT [PK_MemorabiliaPerson] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MemorabiliaPerson_Memorabilia] FOREIGN KEY ([MemorabiliaId]) REFERENCES [dbo].[Memorabilia] ([Id]),
    CONSTRAINT [FK_MemorabiliaPerson_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id])
);

