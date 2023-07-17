using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs.Concert
{
    public class CategoryAddDto 
    {
        [DisplayName("Adı")]
        [Required(ErrorMessage ="{0} alanı boş geçilmemelidir.")]
        [MaxLength(50,ErrorMessage ="{0} {1} karakterden fazla olmamalıdır.")]
        [MinLength(3,ErrorMessage ="{0} {1} karakterden az olmamalıdır.")]
        public string Name { get; set; }
        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(500, ErrorMessage = "{0} {1} karakterden fazla olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden az olmamalıdır.")]
        public string Description { get; set; }
        [DisplayName("Aktif mi?")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public bool IsActive { get; set; }
        [DisplayName("Silindi mi?")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public bool IsDeleted { get; set; }
    }
}
