using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public partial class Messages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MessageId { get; set; }

        public int SenderId { get; set; }

        public int ReciverId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public bool IsRead { get; set; }

        public string Text { get; set; }

        private static int _baseId = 0;
        public static int GenerateId()
        {
            var id = _baseId;
            using (var db = new Model1())
            {
                while (true)
                {
                    if (db.Messages.First(m => m.MessageId == id) == null)
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