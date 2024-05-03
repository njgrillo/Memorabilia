CREATE TABLE [dbo].[PersonCollege] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [PersonId]  INT NOT NULL,
    [CollegeId] INT NOT NULL,
    [BeginYear] INT NULL,
    [EndYear]   INT NULL,
    CONSTRAINT [PK_PersonCollege] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PersonCollege_College] FOREIGN KEY ([CollegeId]) REFERENCES [dbo].[College] ([Id]),
    CONSTRAINT [FK_PersonCollege_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id])
);

