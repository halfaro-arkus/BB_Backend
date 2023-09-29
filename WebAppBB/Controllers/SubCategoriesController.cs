using Microsoft.AspNetCore.Mvc;
using WebAppBB.Dtos;
using WebAppBB.Models;
using WebAppBB.Services;

namespace WebAppBB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubCategoriesController : ControllerBase
    {
        private readonly SubCategoriesService _subCategoriesService;

        public SubCategoriesController(SubCategoriesService subCategoriesService)
        {
            _subCategoriesService = subCategoriesService;
        }

        [HttpPost()]
        public async Task<IActionResult> CreateSubcategory([FromBody] Subcategory request)
        {
            BaseResponse<Subcategory> baseResponse = new BaseResponse<Subcategory>();
            try
            {
                Subcategory? result = await _subCategoriesService.SaveSubcategory(request);
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
        public async Task<IActionResult> UpdateSubcategory([FromBody] Subcategory request)
        {
            BaseResponse<Subcategory> baseResponse = new BaseResponse<Subcategory>();
            try
            {
                Subcategory? result = await _subCategoriesService.UpdateSubcategory(request);
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

        [HttpDelete("/{subcategoryId}")]
        public async Task<IActionResult> DeleteSubcategory(int subcategoryId)
        {
            BaseResponse<string> baseResponse = new BaseResponse<string>();
            try
            {
                await _subCategoriesService.DeleteSubcategory(subcategoryId);
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

        [HttpGet("/{subcategoryId}")]
        public async Task<IActionResult> GetSubcategory(int subcategoryId)
        {
            BaseResponse<Subcategory> baseResponse = new BaseResponse<Subcategory>();
            try
            {
                Subcategory result = await _subCategoriesService.GetSubcategory(subcategoryId);
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
        [HttpGet("/categories/{categoryId}")]
        public async Task<IActionResult> GetAllSubcategoryByCategoryId(int categoryId)
        {
            BaseResponse<List<Subcategory>> baseResponse = new BaseResponse<List<Subcategory>>();
            try
            {
                List<Subcategory> result = await _subCategoriesService.GetAllSubcategoryByCategoryId(categoryId);
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
        public async Task<IActionResult> GetAllActiveSubcategories()
        {
            BaseResponse<List<Subcategory>> baseResponse = new BaseResponse<List<Subcategory>>();
            try
            {
                List<Subcategory> result = await _subCategoriesService.GetAllActiveSubcategories();
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
