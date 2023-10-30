using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Entities.Concrete
{
    public class Category
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "AD")]
        [StringLength(100, ErrorMessage = "Max 100 karakter olmalıdır")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Açıklama")]
        [StringLength(100, ErrorMessage = "Max 100 karakter olmalıdır")]
        public string Descripiton { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
