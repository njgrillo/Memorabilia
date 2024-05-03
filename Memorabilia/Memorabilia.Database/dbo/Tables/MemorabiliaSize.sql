CREATE TABLE [dbo].[MemorabiliaSize] (
    [Id]            INT IDENTITY (1, 1) NOT NULL,
    [MemorabiliaId] INT NOT NULL,
    [SizeId]        INT NOT NULL,
    CONSTRAINT [PK_MemorabiliaSize] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MemorabiliaSize_Memorabilia] FOREIGN KEY ([MemorabiliaId]) REFERENCES [dbo].[Memorabilia] ([Id]),
    CONSTRAINT [FK_MemorabiliaSize_Size] FOREIGN KEY ([SizeId]) REFERENCES [dbo].[Size] ([Id])
);

