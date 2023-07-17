using NLayer.Core.Entities.Abstract;

namespace NLayer.Core.Entities.Concert
{
    public class Comment :BaseEntity, IEntity
    {
        /* IsActive değerini CommentProfile'de yönetiyorum Automapper içerisinde. */
        //public override bool IsActive { get; set; } = false;
        public string Text { get; set; }       
        public int ProductId { get; set; }
        //public int UserId { get; set; }
      
        public Product Product { get; set; }
        //public User User { get; set; }
    }
}
