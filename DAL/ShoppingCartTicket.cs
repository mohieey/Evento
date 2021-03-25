using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ShoppingCartTicket
    {
        public int Id { get; set; }
        [ForeignKey("shoppingCart")]
        public int shoppingCartId { get; set; }
        public virtual ShoppingCart shoppingCart { get; set; }

        [ForeignKey("ticket")]
        public int ticketId { get; set; }
        public virtual Ticket ticket { get; set; }
    }
}
