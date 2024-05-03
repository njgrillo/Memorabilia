CREATE TABLE [dbo].[Autograph] (
    [Id]                  INT             IDENTITY (1, 1) NOT NULL,
    [MemorabiliaId]       INT             NOT NULL,
    [PersonId]            INT             NOT NULL,
    [ConditionId]         INT             NOT NULL,
    [WritingInstrumentId] INT             NOT NULL,
    [ColorId]             INT             NOT NULL,
    [AcquisitionId]       INT             NULL,
    [EstimatedValue]      DECIMAL (12, 2) NULL,
    [Grade]               INT             NULL,
    [CreateDate]          DATETIME        NOT NULL,
    [LastModifiedDate]    DATETIME        NULL,
    [FullName]            BIT             NULL,
    [Numerator]           INT             NULL,
    [Denominator]         INT             NULL,
    [Note]                VARCHAR (MAX)   NULL,
    CONSTRAINT [PK_Autograph] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Autograph_Acquisition] FOREIGN KEY ([AcquisitionId]) REFERENCES [dbo].[Acquisition] ([Id]),
    CONSTRAINT [FK_Autograph_Color] FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Color] ([Id]),
    CONSTRAINT [FK_Autograph_Condition] FOREIGN KEY ([ConditionId]) REFERENCES [dbo].[Condition] ([Id]),
    CONSTRAINT [FK_Autograph_Memorabilia] FOREIGN KEY ([MemorabiliaId]) REFERENCES [dbo].[Memorabilia] ([Id]),
    CONSTRAINT [FK_Autograph_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id]),
    CONSTRAINT [FK_Autograph_WritingInstrument] FOREIGN KEY ([WritingInstrumentId]) REFERENCES [dbo].[WritingInstrument] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Autograph_MemorabiliaId]
    ON [dbo].[Autograph]([MemorabiliaId] ASC);

