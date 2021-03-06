using System.Linq;

namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrainingPlan")]
    public partial class TrainingPlan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrainingPlan()
        {
            Users = new HashSet<Users>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PlanId { get; set; }

        public int? Type { get; set; }

        public int? Level { get; set; }

        public int Coach { get; set; }

        public TrainingType TrainingType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Users> Users { get; set; }

        private static int _baseId = 0;
        public static int GenerateId()
        {
            var id = _baseId;
            using (var db = new Model1())
            {
                while (true)
                {
                    if (db.TrainingPlan.FirstOrDefault(m => m.PlanId == id) == null)
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
