using WebAppBB.Models;

namespace WebAppBB.Dtos
{
    public class PostListDto
    {
        public int PostId { get; set; }
        public string title { get; set; }
        public string? Display { get; set; }
        public string category { get; set; }
    }
}
