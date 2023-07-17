using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs.Concert
{
    public class CommentUpdateDto
    {
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public int Id { get; set; }
        [DisplayName("Yorum")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [MaxLength(1000, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(2, ErrorMessage = "{0} {1} karakterden az olmamalıdır.")]
        public string Text { get; set; }
        [DisplayName("Aktif Mi?")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public bool IsActive { get; set; }
        [DisplayName("Silinmiş Mi?")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public bool IsDeleted { get; set; }
        [DisplayName("Ürün Id")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public int ProductId { get; set; }
    }
}
