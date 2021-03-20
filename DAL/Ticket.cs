using DAL.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table(name: "Ticket")]

    public class Ticket
    {
        public int ID { get; set; }
        public int price { get; set; }
        public Enum_TicketClass @class { get; set; }
        //public int OrderID { get; set; }

        //[ForeignKey("OrderID")]
        //public Order order { get; set; }
        public virtual Event @event { get; set; }
        public virtual ClientUser Client { get; set; } = null;
    }
}