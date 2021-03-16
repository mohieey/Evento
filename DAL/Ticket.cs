using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table(name: "Ticket")]

    public class Ticket
    {
        public int ID { get; set; }
        public Event @event { get; set; }
        public int price { get; set; }
        public bool isBooked { get; set; }
        public int MyProperty { get; set; }
        public Enum_TicketClass @class { get; set; }
        public ApplicationIdentityUser owner { get; set; } = null;

    }
}