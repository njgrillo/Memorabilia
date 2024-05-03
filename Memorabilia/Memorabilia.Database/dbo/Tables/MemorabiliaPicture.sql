CREATE TABLE [dbo].[MemorabiliaPicture] (
    [Id]            INT IDENTITY (1, 1) NOT NULL,
    [MemorabiliaId] INT NOT NULL,
    [OrientationId] INT NOT NULL,
    [PhotoTypeId]   INT NULL,
    [Matted]        BIT NOT NULL,
    [Stretched]     BIT NOT NULL,
    CONSTRAINT [PK_MemorabiliaPicture] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MemorabiliaPicture_Memorabilia] FOREIGN KEY ([MemorabiliaId]) REFERENCES [dbo].[Memorabilia] ([Id]),
    CONSTRAINT [FK_MemorabiliaPicture_Orientation] FOREIGN KEY ([OrientationId]) REFERENCES [dbo].[Orientation] ([Id]),
    CONSTRAINT [FK_MemorabiliaPicture_PhotoType] FOREIGN KEY ([PhotoTypeId]) REFERENCES [dbo].[PhotoType] ([Id])
);

