CREATE TABLE [dbo].[MemorabiliaFigure] (
    [Id]                    INT IDENTITY (1, 1) NOT NULL,
    [MemorabiliaId]         INT NOT NULL,
    [FigureTypeId]          INT NULL,
    [FigureSpecialtyTypeId] INT NULL,
    [Year]                  INT NULL,
    CONSTRAINT [PK_MemorabiliaFigure] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MemorabiliaFigure_FigureSpecialtyType] FOREIGN KEY ([FigureSpecialtyTypeId]) REFERENCES [dbo].[FigureType] ([Id]),
    CONSTRAINT [FK_MemorabiliaFigure_FigureType] FOREIGN KEY ([FigureTypeId]) REFERENCES [dbo].[FigureType] ([Id]),
    CONSTRAINT [FK_MemorabiliaFigure_Memorabilia] FOREIGN KEY ([MemorabiliaId]) REFERENCES [dbo].[Memorabilia] ([Id])
);

