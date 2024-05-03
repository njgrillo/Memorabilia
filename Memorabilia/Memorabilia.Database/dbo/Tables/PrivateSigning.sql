CREATE TABLE [dbo].[PrivateSigning] (
    [Id]                                   INT            IDENTITY (1, 1) NOT NULL,
    [SubmissionDeadlineDate]               DATETIME       NOT NULL,
    [SigningDate]                          DATETIME       NOT NULL,
    [Note]                                 NVARCHAR (MAX) NULL,
    [CreatedUserId]                        INT            NOT NULL,
    [CreatedDate]                          DATETIME       NOT NULL,
    [SelfAddressedStampedEnvelopeAccepted] BIT            NOT NULL,
    [PromoterImageFileName]                NVARCHAR (100) NULL,
    CONSTRAINT [PK_PrivateSigning] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PrivateSigning_CreatedUser] FOREIGN KEY ([CreatedUserId]) REFERENCES [dbo].[User] ([Id])
);

