USE master;
DROP DATABASE Gym;
CREATE DATABASE Gym;
USE Gym; 

CREATE TABLE [Address] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] varchar(255),
  [State] varchar(2) NOT NULL,
  [City] varchar(255) NOT NULL,
  [ZipCode] varchar(8) NOT NULL,
  [Neighborhood] varchar(255) NOT NULL,
  [Street] varchar(255) NOT NULL,
  [Number] int NOT NULL,
  [Complement] varchar(255),
  [Latitude] float NOT NULL,
  [Longitude] float NOT NULL
)
GO

CREATE TABLE [BusinessHour] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [OpeningTime] time NOT NULL,
  [ClosingTime] time NOT NULL,
  [Sunday] bit NOT NULL DEFAULT (0),
  [Monday] bit NOT NULL DEFAULT (0),
  [Tuesday] bit NOT NULL DEFAULT (0),
  [Wednesday] bit NOT NULL DEFAULT (0),
  [Thursday] bit NOT NULL DEFAULT (0),
  [Friday] bit NOT NULL DEFAULT (0),
  [Saturday] bit NOT NULL DEFAULT (0),
  [CompanyId] int NOT NULL
)
GO

CREATE TABLE [Company] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] varchar(255) NOT NULL,
  [CNPJ] varchar(14) UNIQUE NOT NULL,
  [Image] varchar(400),
  [Email] varchar(255),
  [Phone] varchar(11),
  [IsActive] bit NOT NULL DEFAULT (1),
  [AddressId] int NOT NULL
)
GO

CREATE TABLE [User] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] varchar(255) NOT NULL,
  [Email] varchar(255) UNIQUE NOT NULL,
  [Phone] varchar(11) NOT NULL,
  [Password] varchar(MAX) NOT NULL,
  [Role] varchar(60) NOT NULL,
  [CompanyId] int
)
GO

CREATE TABLE [RefreshToken] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Token] varchar(MAX) NOT NULL,
  [Expires] datetime NOT NULL,
  [CreatedAt] datetime NOT NULL,
  [CreatedByIp] varchar(15) NOT NULL,
  [Revoked] datetime,
  [RevokedByIp] varchar(15),
  [ReplacedByToken] varchar(MAX),
  [UserId] int
)
GO

CREATE TABLE [Routine] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] varchar(255) NOT NULL,
  [ExpirationDate] datetime,
  [CreatedBy] int NOT NULL,
  [UpdatedBy] int NOT NULL,
  [StudentId] int,
  [CompanyId] int NOT NULL
)
GO

CREATE TABLE [Workout] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] varchar(255) NOT NULL,
  [Sunday] bit NOT NULL DEFAULT (0),
  [Monday] bit NOT NULL DEFAULT (0),
  [Tuesday] bit NOT NULL DEFAULT (0),
  [Wednesday] bit NOT NULL DEFAULT (0),
  [Thursday] bit NOT NULL DEFAULT (0),
  [Friday] bit NOT NULL DEFAULT (0),
  [Saturday] bit NOT NULL DEFAULT (0),
  [RoutineId] int NOT NULL
)
GO

CREATE TABLE [WorkoutExercise] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Comments] varchar(255),
  [RestBetweenSets] int NOT NULL,
  [MachineNumber] varchar(5),
  [WorkoutId] int NOT NULL,
  [ExerciseId] int NOT NULL
)
GO

CREATE TABLE [Set] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Repetitions] int,
  [Load] int,
  [Duration] int,
  [WorkoutExerciseId] int NOT NULL
)
GO

CREATE TABLE [Exercise] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] varchar(255) UNIQUE NOT NULL
)
GO

CREATE TABLE [Muscle] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] varchar(255) UNIQUE NOT NULL
)
GO

CREATE TABLE [ExerciseMuscle] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [IsPrimary] bit NOT NULL,
  [ExerciseId] int NOT NULL,
  [MuscleId] int NOT NULL
)
GO

CREATE TABLE [ExerciseImage] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Url] varchar(255) NOT NULL,
  [ExerciseId] int NOT NULL
)
GO

CREATE TABLE [Tip] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] varchar(255) NOT NULL,
  [ExerciseId] int NOT NULL
)
GO

CREATE TABLE [Execution] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] varchar(255) NOT NULL,
  [ExerciseId] int NOT NULL
)
GO

ALTER TABLE [BusinessHour] ADD FOREIGN KEY ([CompanyId]) REFERENCES [Company] ([Id])
GO

ALTER TABLE [Company] ADD FOREIGN KEY ([AddressId]) REFERENCES [Address] ([Id])
GO

ALTER TABLE [User] ADD FOREIGN KEY ([CompanyId]) REFERENCES [Company] ([Id])
GO

ALTER TABLE [RefreshToken] ADD FOREIGN KEY ([UserId]) REFERENCES [User] ([Id])
GO

ALTER TABLE [Routine] ADD FOREIGN KEY ([CreatedBy]) REFERENCES [User] ([Id])
GO

ALTER TABLE [Routine] ADD FOREIGN KEY ([UpdatedBy]) REFERENCES [User] ([Id])
GO

ALTER TABLE [Routine] ADD FOREIGN KEY ([StudentId]) REFERENCES [User] ([Id])
GO

ALTER TABLE [Routine] ADD FOREIGN KEY ([CompanyId]) REFERENCES [Company] ([Id])
GO

ALTER TABLE [Workout] ADD FOREIGN KEY ([RoutineId]) REFERENCES [Routine] ([Id])
GO

ALTER TABLE [WorkoutExercise] ADD FOREIGN KEY ([WorkoutId]) REFERENCES [Workout] ([Id])
GO

ALTER TABLE [WorkoutExercise] ADD FOREIGN KEY ([ExerciseId]) REFERENCES [Exercise] ([Id])
GO

ALTER TABLE [Set] ADD FOREIGN KEY ([WorkoutExerciseId]) REFERENCES [WorkoutExercise] ([Id])
GO

ALTER TABLE [ExerciseMuscle] ADD FOREIGN KEY ([ExerciseId]) REFERENCES [Exercise] ([Id])
GO

ALTER TABLE [ExerciseMuscle] ADD FOREIGN KEY ([MuscleId]) REFERENCES [Muscle] ([Id])
GO

ALTER TABLE [ExerciseImage] ADD FOREIGN KEY ([ExerciseId]) REFERENCES [Exercise] ([Id])
GO

ALTER TABLE [Tip] ADD FOREIGN KEY ([ExerciseId]) REFERENCES [Exercise] ([Id])
GO

ALTER TABLE [Execution] ADD FOREIGN KEY ([ExerciseId]) REFERENCES [Exercise] ([Id])
GO


INSERT INTO Muscle ( [Name] )
VALUES 
  ('Shoulders'), --1
  ('Chest'), --2
  ('Biceps'), --3
  ('Abdomen'), --4
  ('Obliques'), --5
  ('Forearm'), --6
  ('Abductors'), --7
  ('Adductors'), --8
  ('Quads'), --9
  ('Traps'), --10
  ('Triceps'), --11
  ('Lats'), --12
  ('Lower back'), --13
  ('Glutes'), --14
  ('Hamstrings'), --15
  ('Calves'), --16
  ('Cardio') --17
GO

INSERT INTO Exercise ( [Name] )
VALUES 
  ('Push-up'),
  ('Military Push-up'),
  ('Diamond Push-up'),
  ('Pull-up'),
  ('Chin-up')
GO

INSERT INTO ExerciseMuscle ( [ExerciseId], [MuscleId], [IsPrimary] )
VALUES
  (1, 2, 1),
  (1, 3, 0),
  (1, 6, 0),
  (1, 11, 0),

  (2, 1, 0),
  (2, 2, 1),
  (2, 3, 0),
  (2, 6, 0),
  (2, 11, 1),

  (3, 1, 1),
  (3, 2, 1),
  (3, 3, 0),
  (3, 6, 0),
  (3, 11, 1),

  (4, 12, 1),
  (4, 3, 1),
  (4, 6, 0),
  (4, 10, 0),
  (4, 11, 0),

  (5, 12, 1),
  (5, 3, 1),
  (5, 6, 0),
  (5, 10, 0),
  (5, 11, 0)
GO

INSERT INTO Address
  (
  [Name], [State], [City], [Neighborhood], [ZipCode],
  [Street], [Number], [Complement], [Latitude],[Longitude]
  )
VALUES
  (
    NULL, 'RJ', 'Rio de Janeiro', 'Bangu', '21820091',
    'Rua Rio da Prata', 1370, 'A', -22.886340, -43.480650
  ),
  (
    NULL, 'RJ', 'Rio de Janeiro', 'Senador Camará', '21840446',
    'Rua Cel. Tamarindo', 4076, NULL, -22.875330, -43.486570
  ),
  (
    NULL, 'RJ', 'Rio de Janeiro', 'Bangu', '21810042',
    'Rua Francisco Real', 2050, NULL, -22.879590, -43.461080
  ),
  (
    NULL, 'RJ', 'Rio de Janeiro', 'Senador Camará', '23010001',
    'Avenida de Santa Cruz', 7138, NULL, -22.893280, -43.533360
  ),
  (
    NULL, 'RJ', 'Rio de Janeiro', 'Bangu', '21715417',
    'Rua Prof. Clemente Ferreira', 1188, NULL, -22.877740, -43.461090
  )
GO

INSERT INTO Company
  (
  [Name], [CNPJ], [Email], [AddressId]
  )
VALUES
  ('Academia do Giga', '12345678910121', 'contato@academia.com', 1),
  ('Academia do Ramon Dino', '12345678910122', 'contato@academia.com', 2),
  ('Academia Calistenia Brasil', '12345678910123', 'contato@academia.com', 3),
  ('Mansão Maromba', '12345678910124', 'contato@academia.com', 4),
  ('Academia do Cariani', '12345678910125', 'contato@academia.com', 5)
GO

