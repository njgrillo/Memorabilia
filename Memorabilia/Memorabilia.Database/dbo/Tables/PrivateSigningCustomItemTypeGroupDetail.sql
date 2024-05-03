CREATE TABLE [dbo].[PrivateSigningCustomItemTypeGroupDetail] (
    [Id]                                  INT             IDENTITY (1, 1) NOT NULL,
    [PrivateSigningCustomItemTypeGroupId] INT             NOT NULL,
    [Cost]                                DECIMAL (12, 2) NOT NULL,
    [ShippingCost]                        DECIMAL (12, 2) NULL,
    CONSTRAINT [PK_PrivateSigningCustomItemTypeGroupDetail] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PrivateSigningCustomItemTypeGroupDetail_PrivateSigningCustomItemTypeGroup] FOREIGN KEY ([PrivateSigningCustomItemTypeGroupId]) REFERENCES [dbo].[PrivateSigningCustomItemTypeGroup] ([Id])
);

