using WebAppBB.Dtos;
using WebAppBB.Models;
using WebAppBB.Repositories;

namespace WebAppBB.Services
{
    public class SubCategoriesService
    {
        private readonly SubCategoriesRepository _subCategoriesRepository;
        public SubCategoriesService(SubCategoriesRepository subCategoriesRepository)
        {
            _subCategoriesRepository = subCategoriesRepository;
        }

        public async Task<Subcategory> SaveSubcategory(Subcategory request)
        {
            try
            {
                return await _subCategoriesRepository.SaveSubcategory(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<Subcategory> UpdateSubcategory(Subcategory request)
        {
            try
            {
                return await _subCategoriesRepository.UpdateSubcategory(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task DeleteSubcategory(int id)
        {
            try
            {
                _subCategoriesRepository.DeleteSubcategory(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<Subcategory> GetSubcategory(int Id)
        {
            try
            {
                return await _subCategoriesRepository.GetSubcategory(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<List<Subcategory>> GetAllSubcategoryByCategoryId(int categoryId)
        {
            try
            {
                return await _subCategoriesRepository.GetAllSubcategoryByCategoryId(categoryId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<List<Subcategory>> GetAllActiveSubcategories()
        {
            try
            {
                return await _subCategoriesRepository.GetAllActiveSubcategories();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
