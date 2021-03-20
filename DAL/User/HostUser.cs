using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.User
{
    public class HostUser  
    {
        [Key,ForeignKey("user")]
        public string Id { get; set; }
        public virtual ApplicationIdentityUser user { get; set; }
        public virtual List<Event> events { get; set; }

    }
}
