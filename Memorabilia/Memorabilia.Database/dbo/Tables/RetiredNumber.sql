CREATE TABLE [dbo].[RetiredNumber] (
    [Id]           INT IDENTITY (1, 1) NOT NULL,
    [PersonId]     INT NOT NULL,
    [FranchiseId]  INT NOT NULL,
    [PlayerNumber] INT NOT NULL,
    CONSTRAINT [PK_RetiredNumber] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RetiredNumber_Franchise] FOREIGN KEY ([FranchiseId]) REFERENCES [dbo].[Franchise] ([Id]),
    CONSTRAINT [FK_RetiredNumber_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id])
);

