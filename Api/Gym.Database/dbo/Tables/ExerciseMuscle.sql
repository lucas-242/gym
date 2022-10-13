CREATE TABLE [dbo].[ExerciseMuscle] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [IsPrimary]  BIT NOT NULL,
    [ExerciseId] INT NOT NULL,
    [MuscleId]   INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ExerciseId]) REFERENCES [dbo].[Exercise] ([Id]),
    FOREIGN KEY ([MuscleId]) REFERENCES [dbo].[Muscle] ([Id])
);

