using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BL.ViewModels
{
    public class HostUserViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public string ID { get; set; }


        [Required, Display(Name = "User Name"), MinLength(5)]
        public string UserName { get; set; }


        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public Enum_Age Age { get; set; }


        public string Address { get; set; }
    }
}
