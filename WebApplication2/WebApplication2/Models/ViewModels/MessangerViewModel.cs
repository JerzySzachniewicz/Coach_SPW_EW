using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.ViewModels
{
    public class MessangerViewModel
    {
        public IEnumerable<Messages> Messages;
        public Messages NewMessage { get; set; }

        public MessangerViewModel()
        {
        }

        public MessangerViewModel(int id, int id2)
        {
            using (var db = new Model1())
            {
                Messages =
                    db.Messages.Where(
                        m => (m.ReciverId == id && m.SenderId == id2) || (m.ReciverId == id2 && m.SenderId == id))
                        .ToList();
            }
        }
    }
}