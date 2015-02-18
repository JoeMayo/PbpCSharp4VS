namespace EntityFrameworkDemo
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MealsContext : DbContext
    {
        public MealsContext()
            : base("name=MealsContext")
        {
        }

        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Meal> Meals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Meal>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Meal>()
                .HasMany(e => e.Ingredients)
                .WithRequired(e => e.Meal)
                .WillCascadeOnDelete(false);
        }
    }
}
