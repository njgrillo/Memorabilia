CREATE TABLE [dbo].[MemorabiliaBasketball] (
    [Id]               INT IDENTITY (1, 1) NOT NULL,
    [MemorabiliaId]    INT NOT NULL,
    [BasketballTypeId] INT NOT NULL,
    CONSTRAINT [PK_MemorabiliaBasketball] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MemorabiliaBasketball_BasketballType] FOREIGN KEY ([BasketballTypeId]) REFERENCES [dbo].[BasketballType] ([Id]),
    CONSTRAINT [FK_MemorabiliaBasketball_Memorabilia] FOREIGN KEY ([MemorabiliaId]) REFERENCES [dbo].[Memorabilia] ([Id])
);

