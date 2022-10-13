CREATE TABLE [dbo].[WorkoutExercise] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [Comments]        VARCHAR (255) NULL,
    [RestBetweenSets] INT           NOT NULL,
    [MachineNumber]   VARCHAR (5)   NULL,
    [WorkoutId]       INT           NOT NULL,
    [ExerciseId]      INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ExerciseId]) REFERENCES [dbo].[Exercise] ([Id]),
    FOREIGN KEY ([WorkoutId]) REFERENCES [dbo].[Workout] ([Id])
);

