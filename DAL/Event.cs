using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table(name:"Event")]
    public class Event
    {
        public int ID { get; set; }
        public DateTime date { get; set; }
        public Enum_Age age { get; set; }
        public string description { get; set; }
        public Enum_Category category { get; set; }
        public int TotalAvailableTickets { get; set; }
        public bool isCanceled { get; set; } = false;

        public virtual Location location { get; set; }
        public virtual List<Ticket> tickets { get; set; }
    }
}