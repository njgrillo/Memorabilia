CREATE TABLE [dbo].[Personalization] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [AutographId] INT           NOT NULL,
    [Text]        VARCHAR (200) NOT NULL,
    CONSTRAINT [PK_Personalization] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Personalization_Autograph] FOREIGN KEY ([AutographId]) REFERENCES [dbo].[Autograph] ([Id])
);

