CREATE TABLE [dbo].[Workout] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (255) NOT NULL,
    [Sunday]    BIT           DEFAULT ((0)) NOT NULL,
    [Monday]    BIT           DEFAULT ((0)) NOT NULL,
    [Tuesday]   BIT           DEFAULT ((0)) NOT NULL,
    [Wednesday] BIT           DEFAULT ((0)) NOT NULL,
    [Thursday]  BIT           DEFAULT ((0)) NOT NULL,
    [Friday]    BIT           DEFAULT ((0)) NOT NULL,
    [Saturday]  BIT           DEFAULT ((0)) NOT NULL,
    [RoutineId] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([RoutineId]) REFERENCES [dbo].[Routine] ([Id])
);

