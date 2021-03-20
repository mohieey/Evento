using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace DAL
{

    public class ApplicationIdentityUser : IdentityUser
    {
        public string SSN { get; set; }
        public string address { get; set; }
        public Enum_Age age { get; set; }
    }
}