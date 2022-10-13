CREATE TABLE [dbo].[RefreshToken] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [Token]           VARCHAR (MAX) NOT NULL,
    [Expires]         DATETIME      NOT NULL,
    [CreatedAt]       DATETIME      NOT NULL,
    [CreatedByIp]     VARCHAR (15)  NOT NULL,
    [Revoked]         DATETIME      NULL,
    [RevokedByIp]     VARCHAR (15)  NULL,
    [ReplacedByToken] VARCHAR (MAX) NULL,
    [UserId]          INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

