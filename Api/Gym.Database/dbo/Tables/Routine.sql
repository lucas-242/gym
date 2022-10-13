CREATE TABLE [dbo].[Routine] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [Name]           VARCHAR (255) NOT NULL,
    [ExpirationDate] DATETIME      NULL,
    [CreatedBy]      INT           NOT NULL,
    [UpdatedBy]      INT           NOT NULL,
    [StudentId]      INT           NULL,
    [CompanyId]      INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Company] ([Id]),
    FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[User] ([Id]),
    FOREIGN KEY ([StudentId]) REFERENCES [dbo].[User] ([Id]),
    FOREIGN KEY ([UpdatedBy]) REFERENCES [dbo].[User] ([Id])
);

