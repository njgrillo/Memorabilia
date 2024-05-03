CREATE TABLE [dbo].[StripePaymentTransaction] (
    [Id]                        INT            IDENTITY (1, 1) NOT NULL,
    [OrderId]                   NVARCHAR (100) NOT NULL,
    [PurchaseUserId]            INT            NOT NULL,
    [TransactionDate]           DATETIME       NOT NULL,
    [StripePaymentStatusTypeId] INT            NOT NULL,
    CONSTRAINT [PK_StripePaymentTransaction] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_StripePaymentTransaction_StripePaymentStatusType] FOREIGN KEY ([StripePaymentStatusTypeId]) REFERENCES [dbo].[StripePaymentStatusType] ([Id]),
    CONSTRAINT [FK_StripePaymentTransaction_User] FOREIGN KEY ([PurchaseUserId]) REFERENCES [dbo].[User] ([Id])
);

