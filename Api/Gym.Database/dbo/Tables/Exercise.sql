CREATE TABLE [dbo].[Exercise] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Name] ASC)
);

