using DAL.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table(name: "Ticket")]

    public class Ticket
    {
        public int ID { get; set; }
        public int price { get; set; }
        public DateTime? date { get; set; }

        [ForeignKey("Event")]
        public int eventId { get; set; }
        public virtual Event Event { get; set; }

        [ForeignKey("Client")]
        public string clientId { get; set; }
        public virtual ClientUser Client { get; set; }

        public virtual List<ShoppingCartTicket> ShoppingCartTicket { get; set; }
        public virtual List<OrderTicket> OrderTicket { get; set; }
    }
}