CREATE TABLE [dbo].[AutographSpot] (
    [Id]          INT IDENTITY (1, 1) NOT NULL,
    [AutographId] INT NOT NULL,
    [SpotId]      INT NOT NULL,
    CONSTRAINT [PK_AutographSpot] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AutographSpot_Autograph] FOREIGN KEY ([AutographId]) REFERENCES [dbo].[Autograph] ([Id]),
    CONSTRAINT [FK_AutographSpot_Spot] FOREIGN KEY ([SpotId]) REFERENCES [dbo].[Spot] ([Id])
);

