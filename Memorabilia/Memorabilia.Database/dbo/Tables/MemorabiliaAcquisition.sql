CREATE TABLE [dbo].[MemorabiliaAcquisition] (
    [Id]            INT IDENTITY (1, 1) NOT NULL,
    [MemorabiliaId] INT NOT NULL,
    [AcquisitionId] INT NOT NULL,
    CONSTRAINT [PK_MemorabiliaAcquisition] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MemorabiliaAcquisition_Acquisition] FOREIGN KEY ([AcquisitionId]) REFERENCES [dbo].[Acquisition] ([Id]),
    CONSTRAINT [FK_MemorabiliaAcquisition_Memorabilia] FOREIGN KEY ([MemorabiliaId]) REFERENCES [dbo].[Memorabilia] ([Id])
);

