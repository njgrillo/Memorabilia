CREATE TABLE [dbo].[SportService] (
    [Id]                   INT      IDENTITY (1, 1) NOT NULL,
    [PersonId]             INT      NOT NULL,
    [DebutDate]            DATETIME NULL,
    [LastAppearanceDate]   DATETIME NULL,
    [FreeAgentSigningDate] DATETIME NULL,
    CONSTRAINT [PK_SportService] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SportService_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id])
);

