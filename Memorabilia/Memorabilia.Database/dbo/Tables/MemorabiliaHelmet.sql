CREATE TABLE [dbo].[MemorabiliaHelmet] (
    [Id]                  INT IDENTITY (1, 1) NOT NULL,
    [MemorabiliaId]       INT NOT NULL,
    [HelmetQualityTypeId] INT NULL,
    [HelmetTypeId]        INT NULL,
    [HelmetFinishId]      INT NULL,
    [Throwback]           BIT NOT NULL,
    CONSTRAINT [PK_MemorabiliaHelmet] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MemorabiliaHelmet_HelmetFinish] FOREIGN KEY ([HelmetFinishId]) REFERENCES [dbo].[HelmetFinish] ([Id]),
    CONSTRAINT [FK_MemorabiliaHelmet_HelmetQualityType] FOREIGN KEY ([HelmetQualityTypeId]) REFERENCES [dbo].[HelmetQualityType] ([Id]),
    CONSTRAINT [FK_MemorabiliaHelmet_HelmetType] FOREIGN KEY ([HelmetTypeId]) REFERENCES [dbo].[HelmetType] ([Id]),
    CONSTRAINT [FK_MemorabiliaHelmet_Memorabilia] FOREIGN KEY ([MemorabiliaId]) REFERENCES [dbo].[Memorabilia] ([Id])
);

