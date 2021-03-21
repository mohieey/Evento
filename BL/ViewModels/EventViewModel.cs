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
        public virtual HostUser Host { get; set; }

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

        [Display(Name ="Canceled?")]
        public bool isCanceled { get; set; }

        //[Required]


        public string description { get; set; }
        public string location { get; set; }

    }
}
