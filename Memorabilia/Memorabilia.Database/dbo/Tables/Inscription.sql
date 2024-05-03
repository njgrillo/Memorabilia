CREATE TABLE [dbo].[Inscription] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [AutographId]       INT            NOT NULL,
    [InscriptionTypeId] INT            NOT NULL,
    [InscriptionText]   VARCHAR (1000) NOT NULL,
    CONSTRAINT [PK_Inscription] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Inscription_Autograph] FOREIGN KEY ([AutographId]) REFERENCES [dbo].[Autograph] ([Id]),
    CONSTRAINT [FK_Inscription_InscriptionType] FOREIGN KEY ([InscriptionTypeId]) REFERENCES [dbo].[InscriptionType] ([Id])
);

