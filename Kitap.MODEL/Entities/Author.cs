using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap.MODEL.Entities
{
   public class Author:NameSpecific
    {
        public Author()
        {
            Books = new List<Book>();
        }

        [Display(Name="Soyisim")]
        public override string SPName { get ; set ; }


        //Relational Properties

        public virtual List<Book> Books { get; set; }

    }
}
