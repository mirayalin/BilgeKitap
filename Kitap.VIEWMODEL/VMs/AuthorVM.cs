using Kitap.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap.VIEWMODEL.VMs
{
   public class AuthorVM:NameSpecific
    {
        [Display(Name ="LastName")]
        public override string SPName { get; set; }


    }
}
