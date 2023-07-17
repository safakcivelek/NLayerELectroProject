using Microsoft.AspNetCore.Identity;

namespace NLayer.Core.Entities.Concert
{
    /* <int> Buradaki int'in anlamı int bir primeryKey kullanmasını istedik.İstersek string Guid bir tip'de kullanılabilir. */
    public class User : IdentityUser<int>
    {
        public string Picture { get; set; }
        public string About { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string YoutubeLink { get; set; }
        public string TwitterLink { get; set; }
        public string InstagramLink { get; set; }
        public string FacebookLink { get; set; }
        public string LinkedInLink { get; set; }
        public string GitHubLink { get; set; }
        public string WebsiteLink { get; set; }

        public ICollection<Order> Orders { get; set; }        
        public ICollection<Comment> Comments { get; set; }     
    }
}
