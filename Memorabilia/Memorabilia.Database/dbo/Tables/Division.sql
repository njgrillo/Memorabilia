CREATE TABLE [dbo].[Division] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [ConferenceId]  INT            NULL,
    [LeagueId]      INT            NULL,
    [Name]          NVARCHAR (100) NOT NULL,
    [Abbreviation]  NVARCHAR (10)  NULL,
    [ImageFileName] NVARCHAR (100) NULL,
    CONSTRAINT [PK_Division] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Division_Conference] FOREIGN KEY ([ConferenceId]) REFERENCES [dbo].[Conference] ([Id]),
    CONSTRAINT [FK_Division_League] FOREIGN KEY ([LeagueId]) REFERENCES [dbo].[League] ([Id])
);

