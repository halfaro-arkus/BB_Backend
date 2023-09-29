using WebAppBB.Models;
using WebAppBB.Repositories;

namespace WebAppBB.Services
{
    public class InteriorCategoriesService
    {
        private readonly InteriorCategoriesRepository _InteriorCategoriesRepository;
        public InteriorCategoriesService(InteriorCategoriesRepository InteriorCategoriesRepository)
        {
            _InteriorCategoriesRepository = InteriorCategoriesRepository;
        }

        public async Task<Interiorcategory> SaveInteriorcategory(Interiorcategory request)
        {
            try
            {
                return await _InteriorCategoriesRepository.SaveInteriorcategory(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<Interiorcategory> UpdateInteriorcategory(Interiorcategory request)
        {
            try
            {
                return await _InteriorCategoriesRepository.UpdateInteriorcategory(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task DeleteInteriorcategory(int id)
        {
            try
            {
                _InteriorCategoriesRepository.DeleteInteriorcategory(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<Interiorcategory> GetInteriorcategory(int Id)
        {
            try
            {
                return await _InteriorCategoriesRepository.GetInteriorcategory(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<List<Interiorcategory>> GetAllInteriorcategoryBySubCategoryId(int subcategoryId)
        {
            try
            {
                return await _InteriorCategoriesRepository.GetAllInteriorcategoryBySubCategoryId(subcategoryId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<List<Interiorcategory>> GetAllActiveInteriorcategories()
        {
            try
            {
                return await _InteriorCategoriesRepository.GetAllActiveInteriorcategories();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
