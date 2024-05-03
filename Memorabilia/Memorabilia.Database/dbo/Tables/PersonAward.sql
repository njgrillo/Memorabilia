CREATE TABLE [dbo].[PersonAward] (
    [Id]          INT IDENTITY (1, 1) NOT NULL,
    [PersonId]    INT NOT NULL,
    [AwardTypeId] INT NOT NULL,
    [Year]        INT NOT NULL,
    CONSTRAINT [PK_PersonAward] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PersonAward_AwardType] FOREIGN KEY ([AwardTypeId]) REFERENCES [dbo].[AwardType] ([Id]),
    CONSTRAINT [FK_PersonAward_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id])
);

