CREATE TABLE [dbo].[ProjectHelmet] (
    [Id]             INT IDENTITY (1, 1) NOT NULL,
    [ProjectId]      INT NOT NULL,
    [HelmetTypeId]   INT NOT NULL,
    [SizeId]         INT NULL,
    [HelmetFinishId] INT NULL,
    CONSTRAINT [PK_ProjectHelmet] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProjectHelmet_HelmetFinish] FOREIGN KEY ([HelmetFinishId]) REFERENCES [dbo].[HelmetFinish] ([Id]),
    CONSTRAINT [FK_ProjectHelmet_HelmetType] FOREIGN KEY ([HelmetTypeId]) REFERENCES [dbo].[HelmetType] ([Id]),
    CONSTRAINT [FK_ProjectHelmet_Project] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Project] ([Id]),
    CONSTRAINT [FK_ProjectHelmet_Size] FOREIGN KEY ([SizeId]) REFERENCES [dbo].[Size] ([Id])
);

