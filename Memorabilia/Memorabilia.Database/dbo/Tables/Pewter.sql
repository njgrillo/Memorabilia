CREATE TABLE [dbo].[Pewter] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [FranchiseId]   INT            NOT NULL,
    [TeamId]        INT            NOT NULL,
    [SizeId]        INT            NOT NULL,
    [ImageTypeId]   INT            NULL,
    [ImageFileName] NVARCHAR (100) NULL,
    CONSTRAINT [PK_Pewter] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Pewter_Franchise] FOREIGN KEY ([FranchiseId]) REFERENCES [dbo].[Franchise] ([Id]),
    CONSTRAINT [FK_Pewter_ImageType] FOREIGN KEY ([ImageTypeId]) REFERENCES [dbo].[ImageType] ([Id]),
    CONSTRAINT [FK_Pewter_Size] FOREIGN KEY ([SizeId]) REFERENCES [dbo].[Size] ([Id]),
    CONSTRAINT [FK_Pewter_Team] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Team] ([Id])
);

