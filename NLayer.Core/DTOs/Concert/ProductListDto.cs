using NLayer.Core.DTOs.Abstract;
using NLayer.Core.Entities.Concert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs.Concert
{
    public class ProductListDto :GetBaseDto
    {
        public IList<Product> Products { get; set; }       
        // Ürünün kategorisine göre sayfalama yapmak istersem.
        public int? CategoryId { get; set; }

    }
}
