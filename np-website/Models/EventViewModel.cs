using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace np_website.Models
{
    public class EventViewModel
    {
        public List<EventItemModel> Events { get; set; }

        public void SaveChanges()
        {
            using (var db = new Database.NPGuildEntities())
            {
                var allEventIds = db.Events.Select(f => f.EventId);
                var recsToRemove = new List<int>();

                foreach(var id in allEventIds)
                    if (!Events.Any(f => f.EventId == id))
                        recsToRemove.Add(id);

                foreach (var id in recsToRemove)
                {
                    var rec = db.Events.Find(id);
                    rec.Removed = true;
                    db.SaveChanges();
                }

                db.SaveChanges();

                foreach (var item in Events)
                {
                    if (item.EventId > 0)
                    {
                        var rec = db.Events.Find(item.EventId);

                        rec.EventDateTime = item.EventDateTime.Value;
                        rec.Description = item.Description;
                        rec.Leader = item.Leader;

                        db.SaveChanges();
                    }
                    else
                    {
                        var rec = new Database.Event()
                        {
                            EventDateTime = item.EventDateTime.Value,
                            Description = item.Description,
                            Leader = item.Leader,
                            Removed = false
                        };

                        db.Events.Add(rec);
                        db.SaveChanges();

                        item.EventId = rec.EventId;
                    }
                }

            }
        }

    }
}