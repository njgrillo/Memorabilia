CREATE TABLE [dbo].[Memorabilia] (
    [Id]               INT             IDENTITY (1, 1) NOT NULL,
    [ItemTypeId]       INT             NOT NULL,
    [ConditionId]      INT             NULL,
    [EstimatedValue]   DECIMAL (12, 2) NULL,
    [PrivacyTypeId]    INT             NOT NULL,
    [UserId]           INT             NOT NULL,
    [CreateDate]       DATETIME        NOT NULL,
    [LastModifiedDate] DATETIME        NULL,
    [Numerator]        INT             NULL,
    [Denominator]      INT             NULL,
    [Note]             VARCHAR (MAX)   NULL,
    [Framed]           BIT             CONSTRAINT [D_Memorabilia_Framed] DEFAULT ((0)) NOT NULL,
    [ForTrade]         BIT             NULL,
    CONSTRAINT [PK_Memorabilia] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Memorabilia_Condition] FOREIGN KEY ([ConditionId]) REFERENCES [dbo].[Condition] ([Id]),
    CONSTRAINT [FK_Memorabilia_ItemType] FOREIGN KEY ([ItemTypeId]) REFERENCES [dbo].[ItemType] ([Id]),
    CONSTRAINT [FK_Memorabilia_PrivacyType] FOREIGN KEY ([PrivacyTypeId]) REFERENCES [dbo].[PrivacyType] ([Id]),
    CONSTRAINT [FK_Memorabilia_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Memorabilia_UserId]
    ON [dbo].[Memorabilia]([UserId] ASC);

