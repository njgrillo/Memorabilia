CREATE TABLE [dbo].[PrivateSigningPersonDetail] (
    [Id]                                        INT            IDENTITY (1, 1) NOT NULL,
    [PrivateSigningPersonId]                    INT            NOT NULL,
    [PrivateSigningItemTypeGroupId]             INT            NOT NULL,
    [PrivateSigningCustomItemTypeGroupDetailId] INT            NULL,
    [Note]                                      NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_PrivateSigningPersonDetail] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PrivateSigningPersonDetail_PrivateSigningCustomItemTypeGroupDetail] FOREIGN KEY ([PrivateSigningCustomItemTypeGroupDetailId]) REFERENCES [dbo].[PrivateSigningCustomItemTypeGroupDetail] ([Id]),
    CONSTRAINT [FK_PrivateSigningPersonDetail_PrivateSigningItemTypeGroup] FOREIGN KEY ([PrivateSigningItemTypeGroupId]) REFERENCES [dbo].[PrivateSigningItemTypeGroup] ([Id]),
    CONSTRAINT [FK_PrivateSigningPersonDetail_PrivateSigningPerson] FOREIGN KEY ([PrivateSigningPersonId]) REFERENCES [dbo].[PrivateSigningPerson] ([Id])
);

