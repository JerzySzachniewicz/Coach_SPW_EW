namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            Results = new HashSet<Results>();
            Users1 = new HashSet<Users>();
        }

        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UsserId { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Nick is nessesery!")]
        public string Nick { get; set; }

        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is nessesery!")]
        public string Email { get; set; }

        [StringLength(50)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is nessesery!")]
        public string Password { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        public bool? isTrainer { get; set; }

        public int? Coach { get; set; }

        public int? TrainingPlan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Results> Results { get; set; }

        public virtual TrainingPlan TrainingPlan1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Users> Users1 { get; set; }

        public virtual Users Users2 { get; set; }
    }
}
