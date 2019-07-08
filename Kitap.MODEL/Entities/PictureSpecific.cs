using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap.MODEL.Entities
{
   public abstract class PictureSpecific:NameSpecific
    {
        [Column("Dosya Yolu"), MaxLength(1000)]
        public string ImagePath { get; set; }
    }
}
