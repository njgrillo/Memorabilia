CREATE TABLE [dbo].[MemorabiliaBammer] (
    [Id]            INT IDENTITY (1, 1) NOT NULL,
    [MemorabiliaId] INT NOT NULL,
    [BammerTypeId]  INT NULL,
    [Year]          INT NULL,
    [InPackage]     BIT NOT NULL,
    CONSTRAINT [PK_MemorabiliaBammer] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MemorabiliaBammer_BammerType] FOREIGN KEY ([BammerTypeId]) REFERENCES [dbo].[BammerType] ([Id]),
    CONSTRAINT [FK_MemorabiliaBammer_Memorabilia] FOREIGN KEY ([MemorabiliaId]) REFERENCES [dbo].[Memorabilia] ([Id])
);

