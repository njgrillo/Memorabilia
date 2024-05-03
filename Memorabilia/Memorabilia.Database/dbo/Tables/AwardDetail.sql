CREATE TABLE [dbo].[AwardDetail] (
    [Id]              INT IDENTITY (1, 1) NOT NULL,
    [AwardTypeId]     INT NOT NULL,
    [BeginYear]       INT NOT NULL,
    [EndYear]         INT NULL,
    [NumberOfWinners] INT NULL,
    [MonthAwarded]    INT NULL,
    CONSTRAINT [PK_AwardDetail] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AwardDetail_AwardType] FOREIGN KEY ([AwardTypeId]) REFERENCES [dbo].[AwardType] ([Id])
);

