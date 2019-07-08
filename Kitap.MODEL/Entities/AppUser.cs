using Kitap.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap.MODEL.Entities
{
   public class AppUser:PictureSpecific
    {
        [Required(ErrorMessage ="{0} alanının girilmesi zorunludur."), MaxLength(20,ErrorMessage ="{0} alanına maksimum {1} karakter girilebilir."),MinLength(5,ErrorMessage ="Minimum 5 karakter girebilirsiniz."),Display(Name ="Kullanıcı İsmi")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bu alanın girilmesi zorunludur"), MaxLength(10, ErrorMessage = "{0} alanına maksimum {1} karakter girilebilir"), Display(Name = "Sifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Sifreleriniz uyusmuyor")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }

        public Guid? ActivationCode { get; set; }

        public Role Role { get; set; }

        public bool IsBanned { get; set; }

        public bool IsActive { get; set; }

        [Display(Name ="Soyisim")]
        public override string SPName { get; set; }

        public string Address { get; set; }

        public DateTime BirthDate { get; set; }

        [EmailAddress(ErrorMessage = "Lütfen bir email formatında giriş yapınız")]
        public string Email { get; set; }

        public AppUser()
        {
            IsActive = false;
            IsBanned = false;
            Role = Role.Member;
            ActivationCode = Guid.NewGuid();
        }

        //Relational Properties

        public virtual List<Order> Orders { get; set; }

    }
}
