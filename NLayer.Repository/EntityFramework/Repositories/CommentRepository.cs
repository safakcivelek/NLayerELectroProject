using NLayer.Core.Entities.Concert;
using NLayer.Core.Repositories;
using NLayer.Repository.EntityFramework.Contexts;

namespace NLayer.Repository.EntityFramework.Repositories
{
    public class CommentRepository : GenericRepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(ElectroDbContext context) : base(context)
        {
        }
    }
}
