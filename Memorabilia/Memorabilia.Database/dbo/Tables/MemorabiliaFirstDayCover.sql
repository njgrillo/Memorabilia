CREATE TABLE [dbo].[MemorabiliaFirstDayCover] (
    [Id]            INT      IDENTITY (1, 1) NOT NULL,
    [MemorabiliaId] INT      NOT NULL,
    [Date]          DATETIME NULL,
    CONSTRAINT [PK_MemorabiliaFirstDayCover] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MemorabiliaFirstDayCover_Memorabilia] FOREIGN KEY ([MemorabiliaId]) REFERENCES [dbo].[Memorabilia] ([Id])
);

