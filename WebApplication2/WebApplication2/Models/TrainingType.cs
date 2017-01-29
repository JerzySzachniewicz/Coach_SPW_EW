using System.Linq;

namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrainingType")]
    public partial class TrainingType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrainingType()
        {
            TrainingPlan = new HashSet<TrainingPlan>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TypeId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrainingPlan> TrainingPlan { get; set; }

        private static int _baseId = 0;
        public static int GenerateId()
        {
            var id = _baseId;
            using (var db = new Model1())
            {
                while (true)
                {
                    if (db.TrainingType.FirstOrDefault(m => m.TypeId == id) == null)
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
