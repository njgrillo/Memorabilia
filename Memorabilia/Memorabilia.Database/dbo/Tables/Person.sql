CREATE TABLE [dbo].[Person] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]        NVARCHAR (50)  NOT NULL,
    [LastName]         NVARCHAR (50)  NOT NULL,
    [MiddleName]       NVARCHAR (50)  NULL,
    [Suffix]           NVARCHAR (25)  NULL,
    [Nickname]         NVARCHAR (50)  NULL,
    [LegalName]        NVARCHAR (225) NOT NULL,
    [DisplayName]      NVARCHAR (225) NOT NULL,
    [BirthDate]        DATETIME       NULL,
    [DeathDate]        DATETIME       NULL,
    [CreateDate]       DATETIME       NOT NULL,
    [LastModifiedDate] DATETIME       NULL,
    [ProfileName]      NVARCHAR (225) NULL,
    [ImageFileName]    NVARCHAR (100) NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([Id] ASC)
);

