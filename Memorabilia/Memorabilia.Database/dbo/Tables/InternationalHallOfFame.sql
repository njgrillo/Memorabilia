CREATE TABLE [dbo].[InternationalHallOfFame] (
    [Id]                            INT IDENTITY (1, 1) NOT NULL,
    [PersonId]                      INT NOT NULL,
    [InternationalHallOfFameTypeId] INT NOT NULL,
    [InductionYear]                 INT NULL,
    CONSTRAINT [PK_InternationalHallOfFame] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_InternationalHallOfFame_InternationalHallOfFameType] FOREIGN KEY ([InternationalHallOfFameTypeId]) REFERENCES [dbo].[InternationalHallOfFameType] ([Id]),
    CONSTRAINT [FK_InternationalHallOfFame_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id])
);

