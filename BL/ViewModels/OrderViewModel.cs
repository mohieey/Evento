using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
    public class OrderViewModel
    {
        public int ID { get; set; }
        public List<Ticket> tickets;
        public DateTime date { get; set; }
        public int totalPrice { get; set; }
        public int discount { get; set; }
    }
}
