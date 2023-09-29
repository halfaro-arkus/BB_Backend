using Microsoft.EntityFrameworkCore;
using WebAppBB.Models;

namespace WebAppBB.Repositories
{
    public class SubCategoriesRepository
    {
        private readonly BbContext _bbContext;
        public SubCategoriesRepository(BbContext bbContext)
        {
            _bbContext = bbContext;
        }

        public async Task<Subcategory?> SaveSubcategory(Subcategory request)
        {
            try
            {
                _bbContext.Subcategories.Add(request);
                _bbContext.SaveChanges();

                Subcategory? item = await _bbContext.Subcategories.OrderByDescending(c => c.Subcategoryid).FirstOrDefaultAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteSubcategory(int subcategoryId)
        {
            try
            {

                Subcategory? item = _bbContext.Subcategories.AsQueryable().Where(sc => sc.Subcategoryid == subcategoryId).Select(p => p).FirstOrDefault();
                _bbContext.Subcategories.Remove(item);
                _bbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Subcategory> GetSubcategory(int subcategoryId)
        {
            try
            {
                return _bbContext.Subcategories.AsQueryable().Where(sc => sc.Subcategoryid == subcategoryId).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
       
        public async Task<Subcategory?> UpdateSubcategory(Subcategory request)
        {
            try
            {
                _bbContext.Subcategories.Update(request);
                _bbContext.SaveChanges();

                Subcategory? item = await _bbContext.Subcategories.OrderByDescending(sc => sc.Subcategoryid).FirstOrDefaultAsync();
                return item;
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
                return _bbContext.Subcategories.AsQueryable().Where(sc => sc.Categoryid == categoryId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<List<Subcategory>?> GetAllActiveSubcategories()
        {
            try
            {                
                return _bbContext.Subcategories.Where(sc => sc.active == true).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
