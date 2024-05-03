CREATE TABLE [dbo].[MemorabiliaJerseyNumber] (
    [Id]            INT IDENTITY (1, 1) NOT NULL,
    [MemorabiliaId] INT NOT NULL,
    [Number]        INT NOT NULL,
    CONSTRAINT [PK_MemorabiliaJerseyNumber] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MemorabiliaJerseyNumber_Memorabilia] FOREIGN KEY ([MemorabiliaId]) REFERENCES [dbo].[Memorabilia] ([Id])
);

