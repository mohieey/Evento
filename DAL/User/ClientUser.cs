using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.User
{
    public class ClientUser
    {
        [Key, ForeignKey("user")]
        public string Id { get; set; }
        public virtual ApplicationIdentityUser user { get; set; }

        [ForeignKey("shoppingCart")]
        public int shoppingCartId { get; set; }
        public virtual ShoppingCart shoppingCart { get; set; }

        public virtual ICollection<Order> orders { get; set; }


    }
}
