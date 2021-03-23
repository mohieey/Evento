using DAL.User;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table(name: "Ticket")]

    public class Ticket
    {
        public int ID { get; set; }
        public int price { get; set; }
        public Enum_TicketClass @class { get; set; }
        public DateTime? date { get; set; }

        [ForeignKey("order")]
        public int OrderID { get; set; }
        public Order order { get; set; }

        [ForeignKey("event")]
        public int eventId { get; set; }
        public virtual Event @event { get; set; }

        [ForeignKey("Client")]
        public string clientId { get; set; }
        public virtual ClientUser Client { get; set; }
    }
}