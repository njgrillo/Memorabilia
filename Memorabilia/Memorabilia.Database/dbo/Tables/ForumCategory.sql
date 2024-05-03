CREATE TABLE [dbo].[ForumCategory] (
    [Id]                INT           IDENTITY (1, 1) NOT NULL,
    [Name]              VARCHAR (100) NOT NULL,
    [Abbreviation]      VARCHAR (10)  NULL,
    [CanBeSportRelated] BIT           NOT NULL,
    CONSTRAINT [PK_ForumCategory] PRIMARY KEY CLUSTERED ([Id] ASC)
);

