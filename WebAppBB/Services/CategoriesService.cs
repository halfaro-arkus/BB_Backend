using WebAppBB.Dtos;
using WebAppBB.Models;
using WebAppBB.Repositories;

namespace WebAppBB.Services
{
    public class CategoriesService
    {
        private readonly CategoriesRepository _CategoriesRepository;
        public CategoriesService(CategoriesRepository CategoriesRepository)
        {
            _CategoriesRepository = CategoriesRepository;
        }

        public async Task<Category> SaveCategory(Category request)
        {
            try
            {
                return await _CategoriesRepository.SaveCategory(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<Category> UpdateCategory(Category request)
        {
            try
            {
                return await _CategoriesRepository.UpdateCategory(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task DeleteCategory(int id)
        {
            try
            {
                _CategoriesRepository.DeleteCategory(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<Category> GetCategory(int Id)
        {
            try
            {
                return await _CategoriesRepository.GetCategory(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<List<Category>> GetAllCategories()
        {
            try
            {
                return await _CategoriesRepository.GetAllCategories();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<ContentCategoriesResponse> GetManageContentCategories()
        {
            try
            {
                return await _CategoriesRepository.GetManageContentCategories();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
