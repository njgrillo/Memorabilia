CREATE TABLE [dbo].[SignatureIdentificationPerson] (
    [Id]                        INT            IDENTITY (1, 1) NOT NULL,
    [SignatureIdentificationId] INT            NOT NULL,
    [PersonId]                  INT            NOT NULL,
    [Note]                      NVARCHAR (MAX) NULL,
    [CreatedUserId]             INT            NOT NULL,
    [CreateDate]                DATETIME       NOT NULL,
    CONSTRAINT [PK_SignatureIdentificationPerson] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SignatureIdentificationPerson_CreatedUser] FOREIGN KEY ([CreatedUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_SignatureIdentificationPerson_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id]),
    CONSTRAINT [FK_SignatureIdentificationPerson_SignatureIdentification] FOREIGN KEY ([SignatureIdentificationId]) REFERENCES [dbo].[SignatureIdentification] ([Id])
);

