CREATE TABLE [dbo].[PrivateSigningCustomItemGroup] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (200) NOT NULL,
    [CreatedByUserId] INT            NOT NULL,
    [CreatedDate]     DATETIME       NOT NULL,
    CONSTRAINT [PK_PrivateSigningCustomItemGroup] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PrivateSigningCustomItemGroup_User] FOREIGN KEY ([CreatedByUserId]) REFERENCES [dbo].[User] ([Id])
);

