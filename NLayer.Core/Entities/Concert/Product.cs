using NLayer.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
namespace NLayer.Core.Entities.Concert
{
    public class Product : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double Discount { get; set; }
        public bool IsDiscounted { get; set; } = false;
        public int StarPoint { get; set; } = 0; // Bu alanı default 0 vermelimiyim?
        public int StarGivenUserCount { get; set; } = 0; // Ürün eklendiğinde verilen yıldız sayısı olmaz.(0)
        public int CategoryId { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int CommentCount { get; set; }

        public Category Category { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<Comment> Comments { get; set; }
        
    }
}
