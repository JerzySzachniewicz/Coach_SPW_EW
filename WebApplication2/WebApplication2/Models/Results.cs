using System.Linq;

namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Results
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ResultId { get; set; }

        public int? Users_Id { get; set; }

        public double? Height { get; set; }

        public double? Weights { get; set; }

        public double? BodyFat { get; set; }

        public double? ChestCircumference { get; set; }

        public double? BicepsCircumference { get; set; }

        public double? Waist { get; set; }

        public double? ThighCircumference { get; set; }

        public virtual Users Users { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        private static int _baseId = 0;
        public static int GenerateId()
        {
            var id = _baseId;
            using (var db = new Model1())
            {
                while (true)
                {
                    if (db.Results.FirstOrDefault(m => m.ResultId == id) == null)
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
