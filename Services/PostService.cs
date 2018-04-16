using Repositories.Repositories;

namespace Services
{
    public class PostService
    {
        private readonly PostRepository Pr = new PostRepository();

        public int DeletePost(int postId) => Pr.RemovePost(postId);

    }
}
