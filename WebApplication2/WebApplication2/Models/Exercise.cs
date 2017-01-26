namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Exercise")]
    public partial class Exercise
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ExerciseId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int Type { get; set; }
    }
}
