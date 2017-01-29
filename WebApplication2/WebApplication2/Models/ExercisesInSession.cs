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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ExercisesInSessionId { get; set; }

        public int SessionId { get; set; }
        
        public int ExerciseId { get; set; }

        public int? Series { get; set; }

        public int? Repeats { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        private static int _baseId = 0;
        public static int GenerateId()
        {
            var id = _baseId;
            using (var db = new Model1())
            {
                while (true)
                {
                    if (db.ExercisesInSession.FirstOrDefault(m => m.ExercisesInSessionId == id) == null)
                    {
                        _baseId = id;
                        return id;
                    }
                    id++;
                }
            }
        }
    }
}
