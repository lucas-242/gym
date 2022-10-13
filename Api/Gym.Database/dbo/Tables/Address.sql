CREATE TABLE [dbo].[Address] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (255) NULL,
    [State]        VARCHAR (2)   NOT NULL,
    [City]         VARCHAR (255) NOT NULL,
    [ZipCode]      VARCHAR (8)   NOT NULL,
    [Neighborhood] VARCHAR (255) NOT NULL,
    [Street]       VARCHAR (255) NOT NULL,
    [Number]       INT           NOT NULL,
    [Complement]   VARCHAR (255) NULL,
    [Latitude]     FLOAT (53)    NOT NULL,
    [Longitude]    FLOAT (53)    NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

