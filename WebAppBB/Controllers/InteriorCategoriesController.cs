using Microsoft.AspNetCore.Mvc;
using WebAppBB.Dtos;
using WebAppBB.Models;
using WebAppBB.Services;

namespace WebAppBB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InteriorCategoriesController : ControllerBase
    {
        private readonly InteriorCategoriesService _InteriorCategoriesService;

        public InteriorCategoriesController(InteriorCategoriesService InteriorCategoriesService)
        {
            _InteriorCategoriesService = InteriorCategoriesService;
        }

        [HttpPost()]
        public async Task<IActionResult> CreateInteriorcategory([FromBody] Interiorcategory request)
        {
            BaseResponse<Interiorcategory> baseResponse = new BaseResponse<Interiorcategory>();
            try
            {
                Interiorcategory? result = await _InteriorCategoriesService.SaveInteriorcategory(request);
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
        public async Task<IActionResult> UpdateInteriorcategory([FromBody] Interiorcategory request)
        {
            BaseResponse<Interiorcategory> baseResponse = new BaseResponse<Interiorcategory>();
            try
            {
                Interiorcategory? result = await _InteriorCategoriesService.UpdateInteriorcategory(request);
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

        [HttpDelete("/{InteriorcategoryId}")]
        public async Task<IActionResult> DeleteInteriorcategory(int InteriorcategoryId)
        {
            BaseResponse<string> baseResponse = new BaseResponse<string>();
            try
            {
                await _InteriorCategoriesService.DeleteInteriorcategory(InteriorcategoryId);
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

        [HttpGet("/{InteriorcategoryId}")]
        public async Task<IActionResult> GetInteriorcategory(int InteriorcategoryId)
        {
            BaseResponse<Interiorcategory> baseResponse = new BaseResponse<Interiorcategory>();
            try
            {
                Interiorcategory result = await _InteriorCategoriesService.GetInteriorcategory(InteriorcategoryId);
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
        [HttpGet("/subcategories/{subcategoryId}")]
        public async Task<IActionResult> GetAllInteriorcategoryBySubCategoryId(int subcategoryId)
        {
            BaseResponse<List<Interiorcategory>> baseResponse = new BaseResponse<List<Interiorcategory>>();
            try
            {
                List<Interiorcategory> result = await _InteriorCategoriesService.GetAllInteriorcategoryBySubCategoryId(subcategoryId);
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
        public async Task<IActionResult> GetAllActiveInteriorcategories()
        {
            BaseResponse<List<Interiorcategory>> baseResponse = new BaseResponse<List<Interiorcategory>>();
            try
            {
                List<Interiorcategory> result = await _InteriorCategoriesService.GetAllActiveInteriorcategories();
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
