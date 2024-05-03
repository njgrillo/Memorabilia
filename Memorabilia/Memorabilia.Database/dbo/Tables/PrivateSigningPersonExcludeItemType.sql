CREATE TABLE [dbo].[PrivateSigningPersonExcludeItemType] (
    [Id]                     INT            IDENTITY (1, 1) NOT NULL,
    [PrivateSigningPersonId] INT            NOT NULL,
    [ItemTypeId]             INT            NOT NULL,
    [Note]                   NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_PrivateSigningPersonExcludeItemType] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PrivateSigningPersonExcludeItemType_ItemType] FOREIGN KEY ([ItemTypeId]) REFERENCES [dbo].[ItemType] ([Id]),
    CONSTRAINT [FK_PrivateSigningPersonExcludeItemType_PrivateSigningPerson] FOREIGN KEY ([PrivateSigningPersonId]) REFERENCES [dbo].[PrivateSigningPerson] ([Id])
);

