CREATE TABLE [dbo].[Position] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [SportId]      INT           NOT NULL,
    [Name]         NVARCHAR (50) NOT NULL,
    [Abbreviation] NVARCHAR (10) NULL,
    CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Position_Sport] FOREIGN KEY ([SportId]) REFERENCES [dbo].[Sport] ([Id])
);

