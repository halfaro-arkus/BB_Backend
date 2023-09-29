using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using WebAppBB.Dtos;
using WebAppBB.Models;

namespace WebAppBB.Repositories
{
    public class ContentRepository
    {
        private readonly BbContext _bbContext;
        public ContentRepository (BbContext bbContext) {
            _bbContext = bbContext;
        }

        public async Task<Post?> SavePost(Post request)
        {
            try
            {  
                request.created = DateTime.Now;
                request.modified = DateTime.Now;
                _bbContext.Posts.Add(request);
                _bbContext.SaveChanges();

                Post? item = await _bbContext.Posts.OrderByDescending(c=>c.PostId).FirstOrDefaultAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeletePost(int postId)
        {
            


            using (var transaction = _bbContext.Database.BeginTransaction())
            {
                try
                {
                    List<Postscategory> list = _bbContext.Postscategories.AsQueryable().Where(p => p.PostId == postId).ToList();
                    _bbContext.RemoveRange(list);

                    Post? post = _bbContext.Posts.AsQueryable().Where(p => p.PostId == postId).Select(p => p).FirstOrDefault();
                    _bbContext.Posts.Remove(post);
                    
                    _bbContext.SaveChangesAsync();
                     transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    transaction.RollbackAsync();
                    throw new Exception(ex.Message);
                }
            }
        }

        public async Task<Post> GetPost(int postId)
        {                        
                try
                {
                    return _bbContext.Posts.AsQueryable().Where(p => p.PostId == postId).FirstOrDefault();
                    
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
                return (from a in _bbContext.Posts
                        join ca in _bbContext.Postscategories on a.PostId equals ca.PostId
                        join c in _bbContext.Categories on ca.Categoryid equals c.Categoryid                        
                        select new PostListDto
                        {
                            PostId = a.PostId,
                            title= a.Title,
                            Display = a.Display==0? "Hidden": "On Display",
                            category = c.Description,
                            created = a.created,
                            modified= a.modified
                        })
                        .OrderByDescending(p => p.created)
                        .OrderByDescending(p => p.modified)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<Post?> UpdatePost(Post request)
        {
            try
            {
                _bbContext.Posts.Update(request);
                _bbContext.SaveChanges();

                Post? item = await _bbContext.Posts.OrderByDescending(c => c.PostId).FirstOrDefaultAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
