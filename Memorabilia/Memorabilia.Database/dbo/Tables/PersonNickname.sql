CREATE TABLE [dbo].[PersonNickname] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [PersonId] INT           NOT NULL,
    [Nickname] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_PersonNickname] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PersonNickname_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id])
);

