CREATE TABLE [dbo].[MemorabiliaJersey] (
    [Id]                  INT IDENTITY (1, 1) NOT NULL,
    [MemorabiliaId]       INT NOT NULL,
    [JerseyQualityTypeId] INT NOT NULL,
    [JerseyStyleTypeId]   INT NOT NULL,
    [JerseyTypeId]        INT NOT NULL,
    CONSTRAINT [PK_MemorabiliaJersey] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MemorabiliaJersey_JerseyQualityType] FOREIGN KEY ([JerseyQualityTypeId]) REFERENCES [dbo].[JerseyQualityType] ([Id]),
    CONSTRAINT [FK_MemorabiliaJersey_JerseyStyleType] FOREIGN KEY ([JerseyStyleTypeId]) REFERENCES [dbo].[JerseyStyleType] ([Id]),
    CONSTRAINT [FK_MemorabiliaJersey_JerseyType] FOREIGN KEY ([JerseyTypeId]) REFERENCES [dbo].[JerseyType] ([Id]),
    CONSTRAINT [FK_MemorabiliaJersey_Memorabilia] FOREIGN KEY ([MemorabiliaId]) REFERENCES [dbo].[Memorabilia] ([Id])
);

