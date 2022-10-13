using Gym.Application.Persistence;
using Gym.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gym.EntityFramework.Persistence
{
    internal class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {

        }
        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<BusinessHour> BusinessHours { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Execution> Executions { get; set; } = null!;
        public virtual DbSet<Exercise> Exercises { get; set; } = null!;
        public virtual DbSet<ExerciseImage> ExerciseImages { get; set; } = null!;
        public virtual DbSet<ExerciseMuscle> ExerciseMuscles { get; set; } = null!;
        public virtual DbSet<Muscle> Muscles { get; set; } = null!;
        public virtual DbSet<Routine> Routines { get; set; } = null!;
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; } = null!;
        public virtual DbSet<Set> Sets { get; set; } = null!;
        public virtual DbSet<Tip> Tips { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Workout> Workouts { get; set; } = null!;
        public virtual DbSet<WorkoutExercise> WorkoutExercises { get; set; } = null!;

        public Task<int> SaveChangesAsync()
        {
            return SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Complement)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Neighborhood)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BusinessHour>(entity =>
            {
                entity.ToTable("BusinessHour");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.BusinessHours)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BusinessH__Compa__4F7CD00D");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.HasIndex(e => e.Cnpj, "UQ__Company__AA57D6B4F2C27136")
                    .IsUnique();

                entity.Property(e => e.Cnpj)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Company__Address__5070F446");
            });

            modelBuilder.Entity<Execution>(entity =>
            {
                entity.ToTable("Execution");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Exercise)
                    .WithMany(p => p.Executions)
                    .HasForeignKey(d => d.ExerciseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Execution__Exerc__5DCAEF64");
            });

            modelBuilder.Entity<Exercise>(entity =>
            {
                entity.ToTable("Exercise");

                entity.HasIndex(e => e.Name, "UQ__Exercise__737584F6F93DEFB0")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExerciseImage>(entity =>
            {
                entity.ToTable("ExerciseImage");

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Exercise)
                    .WithMany(p => p.ExerciseImages)
                    .HasForeignKey(d => d.ExerciseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExerciseI__Exerc__5BE2A6F2");
            });

            modelBuilder.Entity<ExerciseMuscle>(entity =>
            {
                entity.ToTable("ExerciseMuscle");

                entity.HasOne(d => d.Exercise)
                    .WithMany(p => p.ExerciseMuscles)
                    .HasForeignKey(d => d.ExerciseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExerciseM__Exerc__59FA5E80");

                entity.HasOne(d => d.Muscle)
                    .WithMany(p => p.ExerciseMuscles)
                    .HasForeignKey(d => d.MuscleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExerciseM__Muscl__5AEE82B9");
            });

            modelBuilder.Entity<Muscle>(entity =>
            {
                entity.ToTable("Muscle");

                entity.HasIndex(e => e.Name, "UQ__Muscle__737584F621323715")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Routine>(entity =>
            {
                entity.ToTable("Routine");

                entity.Property(e => e.ExpirationDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Routines)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Routine__Company__5535A963");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.RoutineCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Routine__Created__52593CB8");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.RoutineStudents)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__Routine__Student__5441852A");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.RoutineUpdatedByNavigations)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Routine__Updated__534D60F1");
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.ToTable("RefreshToken");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedByIp)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Expires).HasColumnType("datetime");

                entity.Property(e => e.ReplacedByToken).IsUnicode(false);

                entity.Property(e => e.Revoked).HasColumnType("datetime");

                entity.Property(e => e.RevokedByIp)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Token).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RefreshTokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__RefreshTo__UserI__6FE99F9F");
            });

            modelBuilder.Entity<Set>(entity =>
            {
                entity.ToTable("Set");

                entity.HasOne(d => d.WorkoutExercise)
                    .WithMany(p => p.Sets)
                    .HasForeignKey(d => d.WorkoutExerciseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Set__WorkoutExer__59063A47");
            });

            modelBuilder.Entity<Tip>(entity =>
            {
                entity.ToTable("Tip");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Exercise)
                    .WithMany(p => p.Tips)
                    .HasForeignKey(d => d.ExerciseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tip__ExerciseId__5CD6CB2B");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.Email, "UQ__User__A9D105349B58263F")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__User__CompanyId__5165187F");
            });

            modelBuilder.Entity<Workout>(entity =>
            {
                entity.ToTable("Workout");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Routine)
                    .WithMany(p => p.Workouts)
                    .HasForeignKey(d => d.RoutineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Workout__Routine__5629CD9C");
            });

            modelBuilder.Entity<WorkoutExercise>(entity =>
            {
                entity.ToTable("WorkoutExercise");

                entity.Property(e => e.Comments)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MachineNumber)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.Exercise)
                    .WithMany(p => p.WorkoutExercises)
                    .HasForeignKey(d => d.ExerciseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WorkoutEx__Exerc__5812160E");

                entity.HasOne(d => d.Workout)
                    .WithMany(p => p.WorkoutExercises)
                    .HasForeignKey(d => d.WorkoutId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WorkoutEx__Worko__571DF1D5");
            });
        }
    }
}
