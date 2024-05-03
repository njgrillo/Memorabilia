CREATE TABLE [dbo].[MemorabiliaBook] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [MemorabiliaId] INT           NOT NULL,
    [Title]         VARCHAR (200) NOT NULL,
    [Publisher]     VARCHAR (200) NULL,
    [Edition]       VARCHAR (5)   NULL,
    [HardCover]     BIT           NOT NULL,
    CONSTRAINT [PK_MemorabiliaBook] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MemorabiliaBook_Memorabilia] FOREIGN KEY ([MemorabiliaId]) REFERENCES [dbo].[Memorabilia] ([Id])
);

