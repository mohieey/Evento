using System;
using System.Collections.Generic;

namespace DAL
{

    public class Order
    {
        public int ID { get; set; }
        public List<Ticket> tickets;
        public DateTime date { get; set; }
        public int totalPrice { get; set; }
        public int discount { get; set; }
        public virtual ApplicationIdentityUser appUser { get; set; }
    }

}
