CREATE TABLE [dbo].[AccomplishmentDetail] (
    [Id]                   INT IDENTITY (1, 1) NOT NULL,
    [AccomplishmentTypeId] INT NOT NULL,
    [BeginYear]            INT NULL,
    [EndYear]              INT NULL,
    [Year]                 INT NULL,
    [NumberOfWinners]      INT NOT NULL,
    [MonthAccomplished]    INT NULL,
    CONSTRAINT [PK_AccomplishmentDetail] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AccomplishmentDetail_AccomplishmentType] FOREIGN KEY ([AccomplishmentTypeId]) REFERENCES [dbo].[AccomplishmentType] ([Id])
);

