using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Entities.Concrete
{
    public class Product
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Ad")]
        [StringLength(100, ErrorMessage = "Max 100 karakter olmalıdır")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Açıklama")]
        [StringLength(100, ErrorMessage = "Max 100 karakter olmalıdır")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Stok Adedi")]
        public int Stock { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Popüler")]
        public bool Popular { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Onay")]
        public bool IsApproved { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Resim")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Adet")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Kategori")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Cart> Carts { get; set; }
        public virtual List<Sales> Sales { get; set; }
    }
}
