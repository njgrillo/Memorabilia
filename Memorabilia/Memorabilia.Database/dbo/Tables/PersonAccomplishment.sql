CREATE TABLE [dbo].[PersonAccomplishment] (
    [Id]                   INT      IDENTITY (1, 1) NOT NULL,
    [PersonId]             INT      NOT NULL,
    [AccomplishmentTypeId] INT      NOT NULL,
    [Date]                 DATETIME NULL,
    [Year]                 INT      NULL,
    CONSTRAINT [PK_PersonAccomplishment] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PersonAccomplishment_AccomplishmentType] FOREIGN KEY ([AccomplishmentTypeId]) REFERENCES [dbo].[AccomplishmentType] ([Id]),
    CONSTRAINT [FK_PersonAccomplishment_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id])
);

