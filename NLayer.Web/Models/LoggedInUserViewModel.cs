using NLayer.Core.Entities.Concert;

namespace NLayer.Web.Models
{
    public class LoggedInUserViewModel
    {
        public User User { get; set; }
        public IList<string> Roles { get; set; }
    }
}
