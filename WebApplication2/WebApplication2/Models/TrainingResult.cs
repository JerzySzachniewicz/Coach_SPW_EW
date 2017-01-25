namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrainingResult")]
    public partial class TrainingResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ResultId { get; set; }

        public int UserId { get; set; }

        public int? SessionId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        public int? Setisfaction { get; set; }

        [StringLength(255)]
        public string MoreInfo { get; set; }
    }
}
