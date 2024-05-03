CREATE TABLE [dbo].[ThroughTheMailMemorabilia] (
    [Id]               INT             IDENTITY (1, 1) NOT NULL,
    [ThroughTheMailId] INT             NOT NULL,
    [MemorabiliaId]    INT             NOT NULL,
    [AutographId]      INT             NULL,
    [Cost]             DECIMAL (15, 2) NULL,
    [IsExtraReceived]  BIT             NOT NULL,
    CONSTRAINT [PK_ThroughTheMailMemorabilia] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ThroughTheMailMemorabilia_Autograph] FOREIGN KEY ([AutographId]) REFERENCES [dbo].[Autograph] ([Id]),
    CONSTRAINT [FK_ThroughTheMailMemorabilia_Memorabilia] FOREIGN KEY ([MemorabiliaId]) REFERENCES [dbo].[Memorabilia] ([Id]),
    CONSTRAINT [FK_ThroughTheMailMemorabilia_ThroughTheMail] FOREIGN KEY ([ThroughTheMailId]) REFERENCES [dbo].[ThroughTheMail] ([Id])
);

