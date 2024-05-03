CREATE TABLE [dbo].[Acquisition] (
    [Id]                    INT             IDENTITY (1, 1) NOT NULL,
    [AcquisitionTypeId]     INT             NOT NULL,
    [AcquiredDate]          DATETIME        NULL,
    [PurchaseTypeId]        INT             NULL,
    [Cost]                  DECIMAL (12, 2) NULL,
    [AcquiredWithAutograph] BIT             NULL,
    CONSTRAINT [PK_Acquisition] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Acquisition_AcquisitionType] FOREIGN KEY ([AcquisitionTypeId]) REFERENCES [dbo].[AcquisitionType] ([Id]),
    CONSTRAINT [FK_Acquisition_PurchaseType] FOREIGN KEY ([PurchaseTypeId]) REFERENCES [dbo].[PurchaseType] ([Id])
);

