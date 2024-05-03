CREATE TABLE [dbo].[SignatureReviewImage] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [SignatureReviewId] INT            NOT NULL,
    [FileName]          NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_SignatureReviewImage] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SignatureReviewImage_SignatureReview] FOREIGN KEY ([SignatureReviewId]) REFERENCES [dbo].[SignatureReview] ([Id])
);

