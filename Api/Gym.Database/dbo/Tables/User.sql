CREATE TABLE [dbo].[User] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (255) NOT NULL,
    [Email]     VARCHAR (255) NOT NULL,
    [Phone]     VARCHAR (11)  NOT NULL,
    [Password]  VARCHAR (MAX) NOT NULL,
    [Role]      VARCHAR (60)  NOT NULL,
    [CompanyId] INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Company] ([Id]),
    UNIQUE NONCLUSTERED ([Email] ASC)
);

