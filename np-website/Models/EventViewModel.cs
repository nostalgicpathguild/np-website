using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace np_website.Models
{
    public class EventViewModel
    {
        public List<EventItemModel> Events { get; set; }
        public string Motd { get; set; }


        public void SaveChanges()
        {
            using (var db = new Database.NPGuildEntities())
            {
                var allEventIds = db.Events.Select(f => f.EventId);
                var recsToRemove = new List<int>();

                foreach (var id in allEventIds)
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

                        rec.Start = item.StartDate.Value;
                        rec.End = item.EndDate.Value;
                        rec.Description = item.Description;
                        rec.Leader = item.Leader;

                        db.SaveChanges();
                    }
                    else
                    {
                        var rec = new Database.Event()
                        {
                            Start = item.StartDate.Value,
                            End = item.EndDate.Value,
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


        public string GenerateMotd()
        {
            var items = EventItemModel.GetItems();
            var motd = string.Empty;

            foreach (var e in items)
            {
                var start = e.StartDate.Value;
                var suffix = (start.Day % 10 == 1 && start.Day != 11) ? "st"
                           : (start.Day % 10 == 2 && start.Day != 12) ? "nd"
                           : (start.Day % 10 == 3 && start.Day != 13) ? "rd"
                           : "th";
                var time = start.Minute == 0 ? start.ToString("htt") : start.ToString("h:mtt");
                var leader = string.IsNullOrWhiteSpace(e.Leader) ? string.Empty : $"({e.Leader} on RI)";

                motd += $" || {start.ToString("ddd")} {start.Day}{suffix} {time} est - {e.Description} {leader}";

            }

            return motd;
        }
    }
}