using Microsoft.AspNetCore.Mvc;
using WebAppBB.Dtos;
using WebAppBB.Models;
using WebAppBB.Services;

namespace WebAppBB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoriesService _CategoriesService;

        public CategoriesController(CategoriesService CategoriesService)
        {
            _CategoriesService = CategoriesService;
        }

        [HttpPost()]
        public async Task<IActionResult> CreateCategory([FromBody] Category request)
        {
            BaseResponse<Category> baseResponse = new BaseResponse<Category>();
            try
            {
                Category? result = await _CategoriesService.SaveCategory(request);
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
        public async Task<IActionResult> UpdateCategory([FromBody] Category request)
        {
            BaseResponse<Category> baseResponse = new BaseResponse<Category>();
            try
            {
                Category? result = await _CategoriesService.UpdateCategory(request);
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

        [HttpDelete("/{CategoryId}")]
        public async Task<IActionResult> DeleteCategory(int CategoryId)
        {
            BaseResponse<string> baseResponse = new BaseResponse<string>();
            try
            {
                await _CategoriesService.DeleteCategory(CategoryId);
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

        [HttpGet("/{CategoryId}")]
        public async Task<IActionResult> GetCategory(int CategoryId)
        {
            BaseResponse<Category> baseResponse = new BaseResponse<Category>();
            try
            {
                Category result = await _CategoriesService.GetCategory(CategoryId);
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
        public async Task<IActionResult> GetAllCategories()
        {
            BaseResponse<List<Category>> baseResponse = new BaseResponse<List<Category>>();
            try
            {
                List<Category> result = await _CategoriesService.GetAllCategories();
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

        [HttpGet("/manage")]
        public async Task<IActionResult> GetManageContentCategories()
        {
            BaseResponse<ContentCategoriesResponse> baseResponse = new BaseResponse<ContentCategoriesResponse>();
            try
            {
                ContentCategoriesResponse result = await _CategoriesService.GetManageContentCategories();
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
