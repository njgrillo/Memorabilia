CREATE TABLE [dbo].[ProjectPerson] (
    [Id]                  INT             IDENTITY (1, 1) NOT NULL,
    [ProjectId]           INT             NOT NULL,
    [PersonId]            INT             NOT NULL,
    [ItemTypeId]          INT             NULL,
    [Upgrade]             BIT             NOT NULL,
    [Rank]                INT             NULL,
    [PriorityTypeId]      INT             NULL,
    [ProjectStatusTypeId] INT             NULL,
    [MemorabiliaId]       INT             NULL,
    [AutographId]         INT             NULL,
    [EstimatedCost]       DECIMAL (12, 2) NULL,
    CONSTRAINT [PK_ProjectPerson] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProjectPerson_Autograph] FOREIGN KEY ([AutographId]) REFERENCES [dbo].[Autograph] ([Id]),
    CONSTRAINT [FK_ProjectPerson_ItemType] FOREIGN KEY ([ItemTypeId]) REFERENCES [dbo].[ItemType] ([Id]),
    CONSTRAINT [FK_ProjectPerson_Memorabilia] FOREIGN KEY ([MemorabiliaId]) REFERENCES [dbo].[Memorabilia] ([Id]),
    CONSTRAINT [FK_ProjectPerson_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id]),
    CONSTRAINT [FK_ProjectPerson_PriorityType] FOREIGN KEY ([PriorityTypeId]) REFERENCES [dbo].[PriorityType] ([Id]),
    CONSTRAINT [FK_ProjectPerson_Project] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Project] ([Id]),
    CONSTRAINT [FK_ProjectPerson_ProjectStatusType] FOREIGN KEY ([ProjectStatusTypeId]) REFERENCES [dbo].[ProjectStatusType] ([Id])
);

