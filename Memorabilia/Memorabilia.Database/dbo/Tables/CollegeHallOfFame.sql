CREATE TABLE [dbo].[CollegeHallOfFame] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [PersonId]  INT NOT NULL,
    [CollegeId] INT NOT NULL,
    [SportId]   INT NOT NULL,
    [Year]      INT NULL,
    CONSTRAINT [PK_CollegeHallOfFame] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CollegeHallOfFame_College] FOREIGN KEY ([CollegeId]) REFERENCES [dbo].[College] ([Id]),
    CONSTRAINT [FK_CollegeHallOfFame_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id]),
    CONSTRAINT [FK_CollegeHallOfFame_Sport] FOREIGN KEY ([SportId]) REFERENCES [dbo].[Sport] ([Id])
);

