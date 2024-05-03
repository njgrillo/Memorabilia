CREATE TABLE [dbo].[MemorabiliaBaseball] (
    [Id]                INT         IDENTITY (1, 1) NOT NULL,
    [MemorabiliaId]     INT         NOT NULL,
    [BaseballTypeId]    INT         NOT NULL,
    [Year]              INT         NULL,
    [Anniversary]       VARCHAR (5) NULL,
    [LeaguePresidentId] INT         NULL,
    CONSTRAINT [PK_MemorabiliaBaseball] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MemorabiliaBaseball_BaseballType] FOREIGN KEY ([BaseballTypeId]) REFERENCES [dbo].[BaseballType] ([Id]),
    CONSTRAINT [FK_MemorabiliaBaseball_LeaguePresident] FOREIGN KEY ([LeaguePresidentId]) REFERENCES [dbo].[LeaguePresident] ([Id]),
    CONSTRAINT [FK_MemorabiliaBaseball_Memorabilia] FOREIGN KEY ([MemorabiliaId]) REFERENCES [dbo].[Memorabilia] ([Id])
);

