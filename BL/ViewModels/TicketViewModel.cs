using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BL.ViewModels
{
    public class TicketViewModel
    {
        //[HiddenInput(DisplayValue = false)]
        public int ID { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public int price { get; set; }

        [Required]
        [Display(Name = "Tichet Class")]
        public Enum_TicketClass @class { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        //public Event @event { get; set; }

    }
}
