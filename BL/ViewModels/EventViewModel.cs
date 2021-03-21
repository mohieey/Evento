using DAL;
using DAL.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BL.ViewModels
{
    public class EventViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public string HostId { get; set; }

        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        [Required]
        public DateTime date { get; set; }

        [Required]
        public Enum_Age age { get; set; }

        //[Required]
        public Enum_Category category { get; set; }

        [Required]
        public int TotalAvailableTickets { get; set; }

        //[Required]
       

        public string description { get; set; }
    }
}
