CREATE TABLE [dbo].[PrivateSigningCustomItemTypeGroup] (
    [Id]                              INT IDENTITY (1, 1) NOT NULL,
    [PrivateSigningCustomItemGroupId] INT NOT NULL,
    [ItemTypeId]                      INT NOT NULL,
    CONSTRAINT [PK_PrivateSigningCustomItemTypeGroup] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PrivateSigningCustomItemTypeGroup_ItemType] FOREIGN KEY ([ItemTypeId]) REFERENCES [dbo].[ItemType] ([Id]),
    CONSTRAINT [FK_PrivateSigningCustomItemTypeGroup_PrivateSigningCustomItemGroup] FOREIGN KEY ([PrivateSigningCustomItemGroupId]) REFERENCES [dbo].[PrivateSigningCustomItemGroup] ([Id])
);

