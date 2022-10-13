CREATE TABLE [dbo].[Company] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (255) NOT NULL,
    [CNPJ]      VARCHAR (14)  NOT NULL,
    [Image]     VARCHAR (400) NULL,
    [Email]     VARCHAR (255) NULL,
    [Phone]     VARCHAR (11)  NULL,
    [IsActive]  BIT           DEFAULT ((1)) NOT NULL,
    [AddressId] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address] ([Id]),
    UNIQUE NONCLUSTERED ([CNPJ] ASC)
);

