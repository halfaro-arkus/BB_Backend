using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using WebAppBB.Dtos;
using WebAppBB.Models;
using WebAppBB.Services;

namespace WebAppBB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly ContentService contentService;

        public PostsController (ContentService _contentService) { 
            contentService = _contentService; 
        }

        [HttpPost()]
        public async Task<IActionResult> CreatePost([FromBody] Post request)
        {
            BaseResponse<Post> baseResponse = new BaseResponse<Post>();
            try
            {
                Post? result = await contentService.SavePost(request);
                baseResponse.data = result;
                baseResponse.status = StatusCodes.Status200OK;
                return Ok(baseResponse);
            }
            catch (Exception ex)
            {
                baseResponse.message = ex.Message;
                baseResponse.status = StatusCodes.Status500InternalServerError;
                return StatusCode(StatusCodes.Status500InternalServerError, baseResponse);
            }
        }
        
        [HttpPut()]
        public async Task<IActionResult> UpdatePost([FromBody] Post request)
        {
            BaseResponse<Post> baseResponse = new BaseResponse<Post>();
            try
            {
                Post? result = await contentService.UpdatePost(request);
                baseResponse.data = result;
                baseResponse.status = StatusCodes.Status200OK;
                return Ok(baseResponse);
            }
            catch (Exception ex)
            {
                baseResponse.message = ex.Message;
                baseResponse.status = StatusCodes.Status500InternalServerError;
                return StatusCode(StatusCodes.Status500InternalServerError, baseResponse);
            }
        }

        [HttpDelete()]
        public async Task<IActionResult> DeletePost(int postId)
        {
            BaseResponse<string> baseResponse = new BaseResponse<string>();
            try
            {
                await contentService.DeletePost(postId);
                baseResponse.data = "";
                baseResponse.status = StatusCodes.Status200OK;
                return Ok(baseResponse);
            }
            catch (Exception ex)
            {
                baseResponse.message = ex.Message;
                baseResponse.status = StatusCodes.Status500InternalServerError;
                return StatusCode(StatusCodes.Status500InternalServerError, baseResponse);
            }
        }
        
        [HttpGet("/{postId}")]
        public async Task<IActionResult> GetPost(int postId)
        {
            BaseResponse<Post> baseResponse = new BaseResponse<Post>();
            try
            {
                Post result = await contentService.GetPost(postId);
                baseResponse.data = result;
                baseResponse.status = StatusCodes.Status200OK;
                return Ok(baseResponse);
            }
            catch (Exception ex)
            {
                baseResponse.message = ex.Message;
                baseResponse.status = StatusCodes.Status500InternalServerError;
                return StatusCode(StatusCodes.Status500InternalServerError, baseResponse);
            }
        }
        [HttpGet()]
        public async Task<IActionResult> GetAllPosts()
        {
            BaseResponse<List<PostListDto>> baseResponse = new BaseResponse<List<PostListDto>>();
            try
            {
                List<PostListDto>  result = await contentService.GetAllPosts();
                baseResponse.data = result;
                baseResponse.status = StatusCodes.Status200OK;
                return Ok(baseResponse);
            }
            catch (Exception ex)
            {
                baseResponse.message = ex.Message;
                baseResponse.status = StatusCodes.Status500InternalServerError;
                return StatusCode(StatusCodes.Status500InternalServerError, baseResponse);
            }
        }
    }
}
