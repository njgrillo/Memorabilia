CREATE TABLE [dbo].[ThroughTheMail] (
    [Id]                                         INT           IDENTITY (1, 1) NOT NULL,
    [PersonId]                                   INT           NOT NULL,
    [AddressId]                                  INT           NULL,
    [SentDate]                                   DATETIME      NULL,
    [ReceivedDate]                               DATETIME      NULL,
    [UserId]                                     INT           NOT NULL,
    [Notes]                                      VARCHAR (MAX) NULL,
    [ThroughTheMailFailureTypeId]                INT           NULL,
    [TrackingNumber]                             NVARCHAR (50) NULL,
    [SelfAddressedStampedEnvelopeTrackingNumber] NVARCHAR (50) NULL,
    CONSTRAINT [PK_ThroughTheMail] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ThroughTheMail_Address] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address] ([Id]),
    CONSTRAINT [FK_ThroughTheMail_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id]),
    CONSTRAINT [FK_ThroughTheMail_ThroughTheMailFailureType] FOREIGN KEY ([ThroughTheMailFailureTypeId]) REFERENCES [dbo].[ThroughTheMailFailureType] ([Id]),
    CONSTRAINT [FK_ThroughTheMail_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

