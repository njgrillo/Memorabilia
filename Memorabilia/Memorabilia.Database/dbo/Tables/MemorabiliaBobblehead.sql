CREATE TABLE [dbo].[MemorabiliaBobblehead] (
    [Id]            INT IDENTITY (1, 1) NOT NULL,
    [MemorabiliaId] INT NOT NULL,
    [Year]          INT NULL,
    [HasBox]        BIT NOT NULL,
    CONSTRAINT [PK_MemorabiliaBobblehead] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MemorabiliaBobblehead_Memorabilia] FOREIGN KEY ([MemorabiliaId]) REFERENCES [dbo].[Memorabilia] ([Id])
);

