using NLayer.Core.Entities.Abstract;

namespace NLayer.Core.Entities.Concert
{
    public class Category : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
