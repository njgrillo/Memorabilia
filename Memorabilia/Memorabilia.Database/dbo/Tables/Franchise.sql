CREATE TABLE [dbo].[Franchise] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [SportLeagueLevelId] INT            NOT NULL,
    [Name]               NVARCHAR (100) NOT NULL,
    [Location]           NVARCHAR (100) NOT NULL,
    [FoundYear]          INT            NOT NULL,
    [CreateDate]         DATETIME       NOT NULL,
    [LastModifiedDate]   DATETIME       NULL,
    [ImageFileName]      NVARCHAR (100) NULL,
    CONSTRAINT [PK_Franchise] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Franchise_SportLeagueLevel] FOREIGN KEY ([SportLeagueLevelId]) REFERENCES [dbo].[SportLeagueLevel] ([Id])
);

