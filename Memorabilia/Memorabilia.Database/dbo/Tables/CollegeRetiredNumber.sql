CREATE TABLE [dbo].[CollegeRetiredNumber] (
    [Id]           INT IDENTITY (1, 1) NOT NULL,
    [PersonId]     INT NOT NULL,
    [CollegeId]    INT NOT NULL,
    [PlayerNumber] INT NOT NULL,
    CONSTRAINT [PK_CollegeRetiredNumber] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CollegeRetiredNumber_College] FOREIGN KEY ([CollegeId]) REFERENCES [dbo].[College] ([Id]),
    CONSTRAINT [FK_CollegeRetiredNumber_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id])
);

