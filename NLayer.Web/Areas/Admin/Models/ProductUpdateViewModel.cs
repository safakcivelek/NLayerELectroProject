using NLayer.Core.Entities.Concert;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NLayer.Web.Areas.Admin.Models
{
    public class ProductUpdateViewModel
    {
        [Required]
        public int Id { get; set; }
        [DisplayName("Ürün Adı")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(100, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır..")]
        [MinLength(3, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır..")]
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
        [MinLength(3, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır..")]
        public string Description { get; set; }
        [DisplayName("İndirimli Mi?")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public bool IsDiscounted { get; set; }
        [DisplayName("İndirim Oranı")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public double Discount { get; set; }
        [DisplayName("Küçük Resim")]
        public string ImageUrl { get; set; }
        [DisplayName("Küçük Resim Ekle")]              
        public IFormFile ImageUrlFile { get; set; }
        [DisplayName("Aktif Mi?")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public bool IsActive { get; set; }
        [DisplayName("Silinmiş Mi?")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public bool IsDeleted { get; set; }
        [DisplayName("Kategori")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public int CategoryId { get; set; }
        /* SelectList'i doldurmak için veya kategorilere ihtiyaç olması durumunda. */
        public IList<Category> Categories { get; set; }

        
    }
}
