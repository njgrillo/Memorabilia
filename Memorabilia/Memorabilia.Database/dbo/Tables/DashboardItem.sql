CREATE TABLE [dbo].[DashboardItem] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (100) NOT NULL,
    [Description] VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_DashboardItem] PRIMARY KEY CLUSTERED ([Id] ASC)
);

