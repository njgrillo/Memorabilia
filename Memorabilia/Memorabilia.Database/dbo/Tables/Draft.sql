CREATE TABLE [dbo].[Draft] (
    [Id]          INT IDENTITY (1, 1) NOT NULL,
    [PersonId]    INT NOT NULL,
    [FranchiseId] INT NOT NULL,
    [Year]        INT NOT NULL,
    [Round]       INT NOT NULL,
    [Pick]        INT NULL,
    [Overall]     INT NULL,
    CONSTRAINT [PK_Draft] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Draft_Franchise] FOREIGN KEY ([FranchiseId]) REFERENCES [dbo].[Franchise] ([Id]),
    CONSTRAINT [FK_Draft_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id])
);

