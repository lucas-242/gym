CREATE TABLE [dbo].[BusinessHour] (
    [Id]          INT      IDENTITY (1, 1) NOT NULL,
    [OpeningTime] TIME (7) NOT NULL,
    [ClosingTime] TIME (7) NOT NULL,
    [Sunday]      BIT      DEFAULT ((0)) NOT NULL,
    [Monday]      BIT      DEFAULT ((0)) NOT NULL,
    [Tuesday]     BIT      DEFAULT ((0)) NOT NULL,
    [Wednesday]   BIT      DEFAULT ((0)) NOT NULL,
    [Thursday]    BIT      DEFAULT ((0)) NOT NULL,
    [Friday]      BIT      DEFAULT ((0)) NOT NULL,
    [Saturday]    BIT      DEFAULT ((0)) NOT NULL,
    [CompanyId]   INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Company] ([Id])
);

