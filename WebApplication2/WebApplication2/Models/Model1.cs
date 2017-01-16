namespace WebApplication2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Exercise> Exercise { get; set; }
        public virtual DbSet<ExercisesInSession> ExercisesInSession { get; set; }
        public virtual DbSet<Results> Results { get; set; }
        public virtual DbSet<TrainingPlan> TrainingPlan { get; set; }
        public virtual DbSet<TrainingResult> TrainingResult { get; set; }
        public virtual DbSet<TrainingSession> TrainingSession { get; set; }
        public virtual DbSet<TrainingSessionsInPlan> TrainingSessionsInPlan { get; set; }
        public virtual DbSet<TrainingType> TrainingType { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        public TrainingType GetTrainingTypeBtId(int id)
        {
            return Enumerable.FirstOrDefault(TrainingType, tt => tt.TypeId == id);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ExercisesInSession>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<TrainingPlan>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.TrainingPlan1)
                .HasForeignKey(e => e.TrainingPlan);

            modelBuilder.Entity<TrainingType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<TrainingType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<TrainingType>()
                .HasMany(e => e.TrainingPlan)
                .WithOptional(e => e.TrainingType)
                .HasForeignKey(e => e.Type);

            modelBuilder.Entity<Users>()
                .Property(e => e.Nick)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Results)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.Users_Id);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Users1)
                .WithOptional(e => e.Users2)
                .HasForeignKey(e => e.Coach);
        }
    }
}
