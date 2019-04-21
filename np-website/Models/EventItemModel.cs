using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace np_website.Models
{
    public class EventItemModel
    {
        public int EventId { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EventDateTime { get; set; }

        [Required]
        public string Description { get; set; }

        public string Leader { get; set; }

        public static List<EventItemModel> GetItems()
        {
            using (var db = new Database.NPGuildEntities())
            {
                var events = from p in db.Events
                             where p.Removed == false && p.EventDateTime > DateTime.UtcNow
                             select new EventItemModel
                             {
                                 EventId = p.EventId,
                                 EventDateTime = p.EventDateTime,
                                 Description = p.Description,
                                 Leader = p.Leader
                             };

                return events.OrderBy(f => f.EventDateTime).ToList();
            }
        }

    }
}