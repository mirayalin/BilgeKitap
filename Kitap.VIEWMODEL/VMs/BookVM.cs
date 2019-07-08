using Kitap.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap.VIEWMODEL.VMs
{
   public class BookVM:PictureSpecific
    {
        [Display(Name ="Description")]
        public override string SPName { get; set; }

        public string Publisher { get; set; }

        public decimal? UnitPrice { get; set; }

        public short? UnitInStock { get; set; }
    }
}
