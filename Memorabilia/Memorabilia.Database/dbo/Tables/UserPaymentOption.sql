CREATE TABLE [dbo].[UserPaymentOption] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [PaymentOptionId] INT            NOT NULL,
    [PaymentHandle]   NVARCHAR (100) NOT NULL,
    [IsPrimary]       BIT            NOT NULL,
    [UserId]          INT            NOT NULL,
    CONSTRAINT [PK_UserPaymentOption] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserPaymentOption_PaymentOption] FOREIGN KEY ([PaymentOptionId]) REFERENCES [dbo].[PaymentOption] ([Id]),
    CONSTRAINT [FK_UserPaymentOption_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

