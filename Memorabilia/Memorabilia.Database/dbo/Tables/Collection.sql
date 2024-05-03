CREATE TABLE [dbo].[Collection] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (250) NOT NULL,
    [Description] VARCHAR (MAX) NULL,
    [UserId]      INT           NOT NULL,
    CONSTRAINT [PK_Collection] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Collection_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

