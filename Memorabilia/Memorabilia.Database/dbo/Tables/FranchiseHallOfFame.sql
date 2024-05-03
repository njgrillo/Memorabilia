CREATE TABLE [dbo].[FranchiseHallOfFame] (
    [Id]          INT IDENTITY (1, 1) NOT NULL,
    [PersonId]    INT NOT NULL,
    [FranchiseId] INT NOT NULL,
    [Year]        INT NULL,
    CONSTRAINT [PK_FranchiseHallOfFame] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_FranchiseHallOfFame_Franchise] FOREIGN KEY ([FranchiseId]) REFERENCES [dbo].[Franchise] ([Id]),
    CONSTRAINT [FK_FranchiseHallOfFame_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id])
);

