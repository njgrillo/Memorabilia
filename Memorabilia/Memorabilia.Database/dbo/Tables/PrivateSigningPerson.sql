CREATE TABLE [dbo].[PrivateSigningPerson] (
    [Id]                    INT             IDENTITY (1, 1) NOT NULL,
    [PrivateSigningId]      INT             NOT NULL,
    [PersonId]              INT             NOT NULL,
    [Note]                  NVARCHAR (MAX)  NULL,
    [AllowInscriptions]     BIT             NOT NULL,
    [InscriptionCost]       DECIMAL (12, 2) NULL,
    [SpotsAvailable]        INT             NULL,
    [SpotsReserved]         INT             NULL,
    [SpotsConfirmed]        INT             NULL,
    [PromoterImageFileName] NVARCHAR (100)  NULL,
    CONSTRAINT [PK_PrivateSigningPerson] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PrivateSigningPerson_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id]),
    CONSTRAINT [FK_PrivateSigningPerson_PrivateSigning] FOREIGN KEY ([PrivateSigningId]) REFERENCES [dbo].[PrivateSigning] ([Id])
);

