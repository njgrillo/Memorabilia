CREATE TABLE [dbo].[SignatureIdentification] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Note]          NVARCHAR (MAX) NULL,
    [CreatedUserId] INT            NOT NULL,
    [CreatedDate]   DATETIME       NOT NULL,
    CONSTRAINT [PK_SignatureIdentification] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SignatureIdentification_CreatedUser] FOREIGN KEY ([CreatedUserId]) REFERENCES [dbo].[User] ([Id])
);

