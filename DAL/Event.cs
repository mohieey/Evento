using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table(name:"Event")]
    public class Event
    {
        public int ID { get; set; }
        public Location location { get; set; }
        public DateTime date { get; set; }
        public Enum_Age age { get; set; }
        public List<Ticket> tickets { get; set; }
        public string description { get; set; }
        public Enum_Category category { get; set; }
        

    }
}