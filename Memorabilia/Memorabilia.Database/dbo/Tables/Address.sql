CREATE TABLE [dbo].[Address] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [AddressLine1]    NVARCHAR (150) NOT NULL,
    [AddressLine2]    NVARCHAR (150) NULL,
    [City]            NVARCHAR (150) NOT NULL,
    [StateProvidence] NVARCHAR (75)  NOT NULL,
    [PostalCode]      NVARCHAR (12)  NOT NULL,
    [Country]         NVARCHAR (75)  NOT NULL,
    [SingleLine]      NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED ([Id] ASC)
);

