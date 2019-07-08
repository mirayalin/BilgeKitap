using Kitap.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap.VIEWMODEL.VMs
{
   public class AppUserVM:PictureSpecific
    {
        public string UserName { get; set; }

        public string Password { get; set; }

         [Display(Name ="LastName")]
        public override string SPName { get; set; }

        public string Address { get; set; }



    }
}
