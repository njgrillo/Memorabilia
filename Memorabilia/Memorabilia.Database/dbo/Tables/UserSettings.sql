CREATE TABLE [dbo].[UserSettings] (
    [Id]                    INT            IDENTITY (1, 1) NOT NULL,
    [UserId]                INT            NOT NULL,
    [UseDarkTheme]          BIT            NOT NULL,
    [GoogleEmailAddress]    NVARCHAR (100) NULL,
    [XHandle]               NVARCHAR (50)  NULL,
    [MicrosoftEmailAddress] NVARCHAR (100) NULL,
    [ShippingAddressId]     INT            NULL,
    CONSTRAINT [PK_UserSettings] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserSettings_Address] FOREIGN KEY ([ShippingAddressId]) REFERENCES [dbo].[Address] ([Id]),
    CONSTRAINT [FK_UserSettings_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

