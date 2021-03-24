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
        public int ID { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string HostId { get; set; }
        public HostUser Host { get; set; }

        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime date { get; set; }



        [Required]
        [Display(Name = "Age")]
        public Enum_Age age { get; set; }

        //[Required]
        [Display(Name = "Category")]
        public Enum_Category category { get; set; }

        [Required]
        [Display(Name = "Total Available Tickets")]
        public int TotalAvailableTickets { get; set; }

        public string image { get; set; }

        [Required]
        [Display(Name = "Price")]
        public int price { get; set; }

        [Required]
        public string description { get; set; }
        public string location { get; set; }

    }
}
