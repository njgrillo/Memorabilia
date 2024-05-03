CREATE TABLE [dbo].[MemorabiliaCommissioner] (
    [Id]             INT IDENTITY (1, 1) NOT NULL,
    [MemorabiliaId]  INT NOT NULL,
    [CommissionerId] INT NOT NULL,
    CONSTRAINT [PK_MemorabiliaCommissioner] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MemorabiliaCommissioner_Commissioner] FOREIGN KEY ([CommissionerId]) REFERENCES [dbo].[Commissioner] ([Id]),
    CONSTRAINT [FK_MemorabiliaCommissioner_Memorabilia] FOREIGN KEY ([MemorabiliaId]) REFERENCES [dbo].[Memorabilia] ([Id])
);

