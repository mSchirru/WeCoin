using Domain.Entities;
using Domain.Interfaces.Repositories;
using System.Linq;

namespace Repositories.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public int RemovePost(int postId)
        {
            Post post = Rc.Posts.SingleOrDefault(n => n.PostId == postId);
            return Remove(post);
        }
    }
}
