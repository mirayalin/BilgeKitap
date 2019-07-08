using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap.MODEL.Entities
{
   public class Category:BaseEntity
    {
        public Category()
        {
            Books = new List<Book>();
        }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        //Relational Properties

        public virtual List<Book> Books { get; set; }
    }
}
