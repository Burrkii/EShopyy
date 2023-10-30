using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Entities.Concrete
{
    public class User
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "AD")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Soyad")]
        public string SurName { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "EMail")]
        public string EMail { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Şifre")]
        [StringLength(15, ErrorMessage = "Max 15 karakter olmalıdır")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "AD")]
        [StringLength(15, ErrorMessage = "Max 15 karakter olmalıdır")]
        [Compare("Password", ErrorMessage = "Şifreler Uyuşmamaktadır")]

        public string RePassword { get; set; }
        public string Role { get; set; }
    }
}
