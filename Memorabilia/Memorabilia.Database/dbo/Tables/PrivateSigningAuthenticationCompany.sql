CREATE TABLE [dbo].[PrivateSigningAuthenticationCompany] (
    [Id]                      INT             IDENTITY (1, 1) NOT NULL,
    [PrivateSigningId]        INT             NOT NULL,
    [AuthenticationCompanyId] INT             NOT NULL,
    [Cost]                    DECIMAL (12, 2) NOT NULL,
    CONSTRAINT [PK_PrivateSigningAuthenticationCompany] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PrivateSigningAuthenticationCompany_AuthenticationCompany] FOREIGN KEY ([AuthenticationCompanyId]) REFERENCES [dbo].[AuthenticationCompany] ([Id]),
    CONSTRAINT [FK_PrivateSigningAuthenticationCompany_PrivateSigning] FOREIGN KEY ([PrivateSigningId]) REFERENCES [dbo].[PrivateSigning] ([Id])
);

