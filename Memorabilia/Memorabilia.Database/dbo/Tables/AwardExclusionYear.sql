CREATE TABLE [dbo].[AwardExclusionYear] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [AwardDetailId] INT             NOT NULL,
    [Year]          INT             NOT NULL,
    [Reason]        NVARCHAR (1000) NULL,
    CONSTRAINT [PK_AwardExclusionYear] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AwardExclusionYear_AwardDetail] FOREIGN KEY ([AwardDetailId]) REFERENCES [dbo].[AwardDetail] ([Id])
);

