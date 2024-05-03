CREATE TABLE [dbo].[CollectionMemorabilia] (
    [Id]            INT IDENTITY (1, 1) NOT NULL,
    [CollectionId]  INT NOT NULL,
    [MemorabiliaId] INT NOT NULL,
    CONSTRAINT [PK_CollectionMemorabilia] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CollectionMemorabilia_Collection] FOREIGN KEY ([CollectionId]) REFERENCES [dbo].[Collection] ([Id]),
    CONSTRAINT [FK_CollectionMemorabilia_Memorabilia] FOREIGN KEY ([MemorabiliaId]) REFERENCES [dbo].[Memorabilia] ([Id])
);

