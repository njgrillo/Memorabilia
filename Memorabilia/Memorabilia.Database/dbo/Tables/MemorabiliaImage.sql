CREATE TABLE [dbo].[MemorabiliaImage] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [MemorabiliaId] INT            NOT NULL,
    [UploadDate]    DATETIME       NOT NULL,
    [ImageTypeId]   INT            NOT NULL,
    [FileName]      NVARCHAR (100) NULL,
    CONSTRAINT [PK_MemorabiliaImage] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MemorabiliaImage_ImageType] FOREIGN KEY ([ImageTypeId]) REFERENCES [dbo].[ImageType] ([Id]),
    CONSTRAINT [FK_MemorabiliaImage_Memorabilia] FOREIGN KEY ([MemorabiliaId]) REFERENCES [dbo].[Memorabilia] ([Id])
);

