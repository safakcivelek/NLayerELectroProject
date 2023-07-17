using NLayer.Core.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs.Concert
{
    public class OrderUpdateDto
    {
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public int Id { get; set; }
        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [MaxLength(300, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(2, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        public string Description { get; set; }
        [Required]
        [DisplayName("Sipariş Durumu")]
        [Range(0,6,ErrorMessage ="Lütfen, {1} ve {2} aralığında bir değer giriniz.")]
        public OrderStatus Status { get; set; }
        [DisplayName("Açık Adres")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [MaxLength(300, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(2, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        public string Address { get; set; }
        [DisplayName("Ülke")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(2, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        public string Country { get; set; }
        [DisplayName("Şehir")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(2, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        public string City { get; set; }
        [DisplayName("Post Kodu")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        //[Range(5,5, ErrorMessage = "Lütfen, rakamlardan oluşan {1} haneli bir değer giriniz.  ")]
        public string PostalCode { get; set; }
        [DisplayName("Aktif Mi?")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public bool IsActive { get; set; }
        [DisplayName("Silinmiş Mi?")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public bool IsDeleted { get; set; }
        [DisplayName("Müşteri")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public int UserId { get; set; }
    }
}
