using System.ComponentModel.DataAnnotations;

namespace NLayer.Core.Entities.Concert
{
    public class ShippingDetails
    {
        public string UserName { get; set; }
        [Required(ErrorMessage ="Lütfen adres tanımını giriniz.")]
        public string AddressTitle { get; set; }
        [Required(ErrorMessage = "Lütfen adres bilgisi giriniz.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Lütfen ülke bilgisi giriniz.")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Lütfen şehir bilgisi giriniz.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Lütfen semt bilgisi giriniz.")]
        public string District { get; set; }
        [Required(ErrorMessage = "Lütfen 5 karakterli posta kodu bilgisi giriniz.")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Lütfen açıklama bilgisi giriniz.")]
        public string Description { get; set; }
    }
}
