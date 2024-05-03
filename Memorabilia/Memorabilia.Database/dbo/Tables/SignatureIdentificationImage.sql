CREATE TABLE [dbo].[SignatureIdentificationImage] (
    [Id]                        INT            IDENTITY (1, 1) NOT NULL,
    [SignatureIdentificationId] INT            NOT NULL,
    [FileName]                  NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_SignatureIdentificationImage] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SignatureIdentificationImage_SignatureIdentification] FOREIGN KEY ([SignatureIdentificationId]) REFERENCES [dbo].[SignatureIdentification] ([Id])
);

