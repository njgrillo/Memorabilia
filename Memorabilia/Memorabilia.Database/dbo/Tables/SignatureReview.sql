CREATE TABLE [dbo].[SignatureReview] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [PersonId]      INT            NOT NULL,
    [Note]          NVARCHAR (MAX) NULL,
    [CreatedUserId] INT            NOT NULL,
    [CreatedDate]   DATETIME       NOT NULL,
    CONSTRAINT [PK_SignatureReview] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SignatureReview_CreatedUser] FOREIGN KEY ([CreatedUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_SignatureReview_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id])
);

