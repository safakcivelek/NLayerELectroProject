using NLayer.Core.Entities.Concert;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NLayer.Web.Areas.Admin.Models
{
    public class ProductAddViewModel
    {
        [DisplayName("Ürün Adı")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(100, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır.")]
        public string Name { get; set; }
        [DisplayName("Fiyat")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public decimal Price { get; set; }
        [DisplayName("Stok")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public int Stock { get; set; }
        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(1000, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır..")]
        [MinLength(3, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır.")]
        public string Description { get; set; }

        [Required]
        [DisplayName("İndirim Oranı")]
        [Range(0, double.MaxValue, ErrorMessage = "Lütfen geçerli bir değer girin.")]       
        public double Discount { get; set; }
        [DisplayName("Resim")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]       
        public IFormFile ImageUrlFile { get; set; }
        [DisplayName("Aktif Mi?")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public bool IsActive { get; set; }
        [DisplayName("İndirimli Mi?")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public bool IsDiscounted { get; set; }
        [DisplayName("Kategori")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public int CategoryId { get; set; }
        // SelectList'i doldurmak için kullanılacak.     
        public IList<Category> Categories { get; set; }     
    }
}
