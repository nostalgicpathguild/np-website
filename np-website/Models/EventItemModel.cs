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
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy h:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }

        //[Required]
        //[DisplayFormat(DataFormatString = "{0:h:mm tt}", ApplyFormatInEditMode = true)]
        //public TimeSpan StartTime { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy h:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }

        //[Required]
        //[DisplayFormat(DataFormatString = "{0:h:mm tt}", ApplyFormatInEditMode = true)]
        //public TimeSpan EndTime { get; set; }

        [Required]
        public string Description { get; set; }

        public string Leader { get; set; }

        //public DateTime GetStartDate()
        //{
        //    return new DateTime(StartDate.Value.Year, StartDate.Value.Month, StartDate.Value.Day, StartTime.Hours, StartTime.Minutes, StartTime.Seconds);
        //}

        //public DateTime GetEndDate()
        //{
        //    return new DateTime(EndDate.Value.Year, EndDate.Value.Month, EndDate.Value.Day, EndTime.Hours, EndTime.Minutes, EndTime.Seconds);
        //}

        public static List<EventItemModel> GetItems()
        {
            using (var db = new Database.NPGuildEntities())
            {
                var start = DateTime.UtcNow.AddDays(-1);
                var easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                start += easternZone.BaseUtcOffset;

                var data = from p in db.Events
                           where p.Removed == false && p.Start > start
                           select new
                           {
                               p.EventId,
                               p.Start,
                               p.End,
                               p.Description,
                               p.Leader
                           };

                var events = new List<EventItemModel>();

                foreach(var item in data.ToList())
                {
                    events.Add(new EventItemModel()
                    {
                        EventId = item.EventId,
                        StartDate = item.Start,
                        //StartTime = item.Start.TimeOfDay,
                        EndDate = item.End,
                        //EndTime = item.End.TimeOfDay,
                        Description = item.Description,
                        Leader = item.Leader
                    });
                }

                return events.OrderBy(f => f.StartDate).ToList();
            }
        }

    }
}