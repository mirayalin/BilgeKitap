using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap.MODEL.Entities
{
   public abstract class NameSpecific:BaseEntity
    {

        [Required(ErrorMessage = "Lütfen isim giriniz"), MaxLength(30, ErrorMessage = "Maksimum 30 karakter girebilirsiniz")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Lütfen gerekli ismi giriniz."), MaxLength(30, ErrorMessage = "Maksimum 30 karakter girebilirsiniz")]
        public virtual string SPName { get; set; }



    }
}
