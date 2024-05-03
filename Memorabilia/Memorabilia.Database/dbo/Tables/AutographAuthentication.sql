CREATE TABLE [dbo].[AutographAuthentication] (
    [Id]                      INT          IDENTITY (1, 1) NOT NULL,
    [AutographId]             INT          NOT NULL,
    [AuthenticationCompanyId] INT          NOT NULL,
    [Verification]            VARCHAR (50) NULL,
    [HasHologram]             BIT          NULL,
    [HasLetter]               BIT          NULL,
    [Witnessed]               BIT          NULL,
    [HasCertificationCard]    BIT          NULL,
    CONSTRAINT [PK_AutographAuthentication] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AutographAuthentication_AuthenticationCompany] FOREIGN KEY ([AuthenticationCompanyId]) REFERENCES [dbo].[AuthenticationCompany] ([Id]),
    CONSTRAINT [FK_AutographAuthentication_Autograph] FOREIGN KEY ([AutographId]) REFERENCES [dbo].[Autograph] ([Id])
);

