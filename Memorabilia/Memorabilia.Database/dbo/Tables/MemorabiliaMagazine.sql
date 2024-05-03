CREATE TABLE [dbo].[MemorabiliaMagazine] (
    [Id]            INT      IDENTITY (1, 1) NOT NULL,
    [MemorabiliaId] INT      NOT NULL,
    [OrientationId] INT      NOT NULL,
    [Date]          DATETIME NULL,
    [Framed]        BIT      NOT NULL,
    [Matted]        BIT      NOT NULL,
    CONSTRAINT [PK_MemorabiliaMagazine] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MemorabiliaMagazine_Memorabilia] FOREIGN KEY ([MemorabiliaId]) REFERENCES [dbo].[Memorabilia] ([Id]),
    CONSTRAINT [FK_MemorabiliaMagazine_Orientation] FOREIGN KEY ([OrientationId]) REFERENCES [dbo].[Orientation] ([Id])
);

