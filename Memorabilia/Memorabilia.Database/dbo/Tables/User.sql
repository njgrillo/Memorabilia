CREATE TABLE [dbo].[User] (
    [Id]                         INT            IDENTITY (1, 1) NOT NULL,
    [EmailAddress]               NVARCHAR (100) NOT NULL,
    [FirstName]                  NVARCHAR (50)  NOT NULL,
    [LastName]                   NVARCHAR (50)  NOT NULL,
    [CreateDate]                 DATETIME2 (7)  NOT NULL,
    [UpdateDate]                 DATETIME2 (7)  NULL,
    [Username]                   NVARCHAR (50)  NOT NULL,
    [SubscriptionExpirationDate] DATETIME       NULL,
    [StripeCustomerId]           NVARCHAR (500) NULL,
    [SubscriptionCanceled]       BIT            NOT NULL,
    [StripeSubscriptionId]       NVARCHAR (500) NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
);

