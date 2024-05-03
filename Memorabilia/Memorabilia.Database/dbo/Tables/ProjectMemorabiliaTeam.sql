CREATE TABLE [dbo].[ProjectMemorabiliaTeam] (
    [Id]                  INT             IDENTITY (1, 1) NOT NULL,
    [ProjectId]           INT             NOT NULL,
    [TeamId]              INT             NOT NULL,
    [ItemTypeId]          INT             NULL,
    [Upgrade]             BIT             NOT NULL,
    [Rank]                INT             NULL,
    [PriorityTypeId]      INT             NULL,
    [ProjectStatusTypeId] INT             NULL,
    [MemorabiliaId]       INT             NULL,
    [EstimatedCost]       DECIMAL (12, 2) NULL,
    CONSTRAINT [PK_ProjectMemorabiliaTeam] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProjectMemorabiliaTeam_ItemType] FOREIGN KEY ([ItemTypeId]) REFERENCES [dbo].[ItemType] ([Id]),
    CONSTRAINT [FK_ProjectMemorabiliaTeam_Memorabilia] FOREIGN KEY ([MemorabiliaId]) REFERENCES [dbo].[Memorabilia] ([Id]),
    CONSTRAINT [FK_ProjectMemorabiliaTeam_PriorityType] FOREIGN KEY ([PriorityTypeId]) REFERENCES [dbo].[PriorityType] ([Id]),
    CONSTRAINT [FK_ProjectMemorabiliaTeam_Project] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Project] ([Id]),
    CONSTRAINT [FK_ProjectMemorabiliaTeam_ProjectStatusType] FOREIGN KEY ([ProjectStatusTypeId]) REFERENCES [dbo].[ProjectStatusType] ([Id]),
    CONSTRAINT [FK_ProjectMemorabiliaTeam_Team] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Team] ([Id])
);

