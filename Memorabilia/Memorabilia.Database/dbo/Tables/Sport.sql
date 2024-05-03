CREATE TABLE [dbo].[Sport] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (50)  NOT NULL,
    [AlternateName]    NVARCHAR (50)  NULL,
    [CreateDate]       DATETIME       NOT NULL,
    [LastModifiedDate] DATETIME       NULL,
    [ImageFileName]    NVARCHAR (100) NULL,
    CONSTRAINT [PK_Sport] PRIMARY KEY CLUSTERED ([Id] ASC)
);

