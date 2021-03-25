using DAL.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{

    public class Order
    {
        public int ID { get; set; }
        public int totalPrice { get; set; }

        [ForeignKey("Client")]
        public string clientId { get; set; }
        public virtual ClientUser Client { get; set; }

        public virtual List<OrderTicket> OrderTickets { get; set; }
    }

}
