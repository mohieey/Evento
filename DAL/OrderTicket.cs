using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderTicket
    {
        public int Id { get; set; }

        [ForeignKey("order")]
        public int orderId { get; set; }
        public virtual Order order { get; set; }

        [ForeignKey("ticket")]
        public int ticketId { get; set; }
        public virtual Ticket ticket { get; set; }
    }
}
