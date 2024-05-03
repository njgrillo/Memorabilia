CREATE TABLE [dbo].[Team] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [FranchiseId]   INT            NOT NULL,
    [Name]          NVARCHAR (100) NOT NULL,
    [Location]      NVARCHAR (100) NOT NULL,
    [Nickname]      NVARCHAR (25)  NULL,
    [Abbreviation]  VARCHAR (10)   NULL,
    [BeginYear]     INT            NULL,
    [EndYear]       INT            NULL,
    [ImageFileName] NVARCHAR (100) NULL,
    CONSTRAINT [PK_Team] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Team_Franchise] FOREIGN KEY ([FranchiseId]) REFERENCES [dbo].[Franchise] ([Id]),
    CONSTRAINT [FK_Team_Team] FOREIGN KEY ([Id]) REFERENCES [dbo].[Team] ([Id])
);

