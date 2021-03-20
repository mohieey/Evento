using System;
using System.Collections.Generic;

namespace DAL
{

    public class Order
    {
        public int ID { get; set; }
        public DateTime date { get; set; }
        public int totalPrice { get; set; }
        public int discount { get; set; }

        public virtual List<Ticket> tickets { get; set; }
        public virtual ApplicationIdentityUser appUser { get; set; }
    }

}
