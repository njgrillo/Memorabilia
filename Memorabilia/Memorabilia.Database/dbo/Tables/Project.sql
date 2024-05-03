CREATE TABLE [dbo].[Project] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Name]          VARCHAR (1000) NOT NULL,
    [StartDate]     DATETIME       NULL,
    [EndDate]       DATETIME       NULL,
    [UserId]        INT            NOT NULL,
    [ProjectTypeId] INT            NOT NULL,
    CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Project_ProjectType] FOREIGN KEY ([ProjectTypeId]) REFERENCES [dbo].[ProjectType] ([Id]),
    CONSTRAINT [FK_Project_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

