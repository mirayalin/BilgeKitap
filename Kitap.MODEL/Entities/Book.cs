using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap.MODEL.Entities
{
   public class Book:PictureSpecific
    {

        [Display(Name="Acıklama")]
        public override string SPName { get ; set; }

        public string Publisher { get; set; }

        public decimal UnitPrice { get; set; }

        public short UnitInStock { get; set; }

        public int? AuthorID { get; set; }

        public int? CategoryID { get; set; }

        //Relational Properties

        public virtual Author Author { get; set; }

        public virtual Category Category { get; set; }
    }
}
