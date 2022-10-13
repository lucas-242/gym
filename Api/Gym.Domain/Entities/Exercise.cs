using System;
using System.Collections.Generic;

namespace Gym.Entities
{
    public partial class Exercise
    {
        public Exercise()
        {
            Executions = new HashSet<Execution>();
            ExerciseImages = new HashSet<ExerciseImage>();
            ExerciseMuscles = new HashSet<ExerciseMuscle>();
            Tips = new HashSet<Tip>();
            WorkoutExercises = new HashSet<WorkoutExercise>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Execution> Executions { get; set; }
        public virtual ICollection<ExerciseImage> ExerciseImages { get; set; }
        public virtual ICollection<ExerciseMuscle> ExerciseMuscles { get; set; }
        public virtual ICollection<Tip> Tips { get; set; }
        public virtual ICollection<WorkoutExercise> WorkoutExercises { get; set; }
    }
}
