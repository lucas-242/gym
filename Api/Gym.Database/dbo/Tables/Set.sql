CREATE TABLE [dbo].[Set] (
    [Id]                INT IDENTITY (1, 1) NOT NULL,
    [Repetitions]       INT NULL,
    [Load]              INT NULL,
    [Duration]          INT NULL,
    [WorkoutExerciseId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([WorkoutExerciseId]) REFERENCES [dbo].[WorkoutExercise] ([Id])
);

