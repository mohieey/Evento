using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
    public class EventViewModel
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        [Required]
        public DateTime date { get; set; }

        [Required]
        public Enum_Age age { get; set; }

        [Required]
        public Enum_Category category { get; set; }

        [Required]
        public int TotalAvailableTickets { get; set; }

        [Required]
        public Location location { get; set; }

        public string description { get; set; }
    }
}
