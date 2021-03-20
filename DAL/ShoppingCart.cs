﻿using DAL.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ShoppingCart
    {
        public int ID { get; set; }
        public int totalPrice { get; set; }
       // public string ClientId { get; set; }


        //[Required]
        //[ForeignKey("ClientId")]
        //public virtual ClientUser Client { get; set; }
        public virtual List<Ticket> Tickets { get; set; }
    }
}
