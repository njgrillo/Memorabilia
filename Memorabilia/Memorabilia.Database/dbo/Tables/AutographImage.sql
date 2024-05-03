CREATE TABLE [dbo].[AutographImage] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [AutographId] INT            NOT NULL,
    [UploadDate]  DATETIME       NOT NULL,
    [ImageTypeId] INT            NOT NULL,
    [FileName]    NVARCHAR (100) NULL,
    CONSTRAINT [PK_AutographImage] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AutographImage_Autograph] FOREIGN KEY ([AutographId]) REFERENCES [dbo].[Autograph] ([Id]),
    CONSTRAINT [FK_AutographImage_ImageType] FOREIGN KEY ([ImageTypeId]) REFERENCES [dbo].[ImageType] ([Id])
);

