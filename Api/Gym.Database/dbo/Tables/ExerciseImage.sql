CREATE TABLE [dbo].[ExerciseImage] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Url]        VARCHAR (255) NOT NULL,
    [ExerciseId] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ExerciseId]) REFERENCES [dbo].[Exercise] ([Id])
);

