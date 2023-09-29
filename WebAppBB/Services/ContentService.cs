using WebAppBB.Dtos;
using WebAppBB.Models;
using WebAppBB.Repositories;

namespace WebAppBB.Services
{
    public class ContentService
    {
        private readonly ContentRepository _contentRepository;
        public ContentService(ContentRepository contentRepository) { 
            _contentRepository = contentRepository;  
        }

        public async Task<Post> SavePost(Post request)
        {
            try
            {
                return await _contentRepository.SavePost(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<Post> UpdatePost(Post request)
        {
            try
            {
                request.modified = DateTime.Now;
                return await _contentRepository.UpdatePost(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task DeletePost(int postId)
        {
            try
            {
                _contentRepository.DeletePost(postId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<Post> GetPost(int postId)
        {
            try
            {
                return await _contentRepository.GetPost(postId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<List<PostListDto>> GetAllPosts()
        {
            try
            {
                return await _contentRepository.GetAllPosts();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
