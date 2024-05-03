CREATE TABLE [dbo].[MemorabiliaCard] (
    [Id]            INT IDENTITY (1, 1) NOT NULL,
    [MemorabiliaId] INT NOT NULL,
    [OrientationId] INT NOT NULL,
    [Year]          INT NULL,
    [Licensed]      BIT NOT NULL,
    [Custom]        BIT NOT NULL,
    CONSTRAINT [PK_MemorabiliaCard] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MemorabiliaCard_Memorabilia] FOREIGN KEY ([MemorabiliaId]) REFERENCES [dbo].[Memorabilia] ([Id]),
    CONSTRAINT [FK_MemorabiliaCard_Orientation] FOREIGN KEY ([OrientationId]) REFERENCES [dbo].[Orientation] ([Id])
);

