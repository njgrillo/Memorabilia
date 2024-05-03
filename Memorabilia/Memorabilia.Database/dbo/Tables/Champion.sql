CREATE TABLE [dbo].[Champion] (
    [Id]             INT IDENTITY (1, 1) NOT NULL,
    [ChampionTypeId] INT NOT NULL,
    [TeamId]         INT NOT NULL,
    [Year]           INT NOT NULL,
    CONSTRAINT [PK_Champion] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Champion_ChampionType] FOREIGN KEY ([ChampionTypeId]) REFERENCES [dbo].[ChampionType] ([Id])
);

