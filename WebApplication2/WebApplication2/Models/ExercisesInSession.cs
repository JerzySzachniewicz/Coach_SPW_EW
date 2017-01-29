using System.Linq;

namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExercisesInSession")]
    public partial class ExercisesInSession
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SessionId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ExerciseId { get; set; }

        public int? Series { get; set; }

        public int? Repeats { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

    }
}
