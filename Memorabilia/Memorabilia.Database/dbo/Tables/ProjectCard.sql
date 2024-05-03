CREATE TABLE [dbo].[ProjectCard] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [ProjectId] INT NOT NULL,
    [BrandId]   INT NOT NULL,
    [Year]      INT NULL,
    [TeamId]    INT NULL,
    CONSTRAINT [PK_ProjectCard] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProjectCard_Brand] FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brand] ([Id]),
    CONSTRAINT [FK_ProjectCard_Project] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Project] ([Id]),
    CONSTRAINT [FK_ProjectCard_Team] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Team] ([Id])
);

