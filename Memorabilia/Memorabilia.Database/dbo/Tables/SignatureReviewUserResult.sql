CREATE TABLE [dbo].[SignatureReviewUserResult] (
    [Id]                          INT            IDENTITY (1, 1) NOT NULL,
    [SignatureReviewId]           INT            NOT NULL,
    [SignatureReviewResultTypeId] INT            NOT NULL,
    [Note]                        NVARCHAR (MAX) NULL,
    [CreatedUserId]               INT            NOT NULL,
    [CreatedDate]                 DATETIME       NOT NULL,
    CONSTRAINT [PK_SignatureReviewUserResult] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SignatureReviewUserResult_CreatedUser] FOREIGN KEY ([CreatedUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_SignatureReviewUserResult_SignatureReview] FOREIGN KEY ([SignatureReviewId]) REFERENCES [dbo].[SignatureReview] ([Id]),
    CONSTRAINT [FK_SignatureReviewUserResult_SignatureReviewResultType] FOREIGN KEY ([SignatureReviewResultTypeId]) REFERENCES [dbo].[SignatureReviewResultType] ([Id])
);

