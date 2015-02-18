namespace EntityFrameworkDemo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ingredient")]
    public partial class Ingredient
    {
        public int Id { get; set; }

        public int MealId { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public virtual Meal Meal { get; set; }
    }
}
