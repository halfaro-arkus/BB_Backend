using Microsoft.EntityFrameworkCore;
using WebAppBB.Models;

namespace WebAppBB.Repositories
{
    public class InteriorCategoriesRepository
    {
        private readonly BbContext _bbContext;
        public InteriorCategoriesRepository(BbContext bbContext)
        {
            _bbContext = bbContext;
        }

        public async Task<Interiorcategory?> SaveInteriorcategory(Interiorcategory request)
        {
            try
            {
                _bbContext.Interiorcategories.Add(request);
                _bbContext.SaveChanges();

                Interiorcategory? item = await _bbContext.Interiorcategories.OrderByDescending(c => c.Interiorcategoryid).FirstOrDefaultAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteInteriorcategory(int InteriorcategoryId)
        {
            try
            {

                Interiorcategory? item = _bbContext.Interiorcategories.AsQueryable().Where(sc => sc.Interiorcategoryid == InteriorcategoryId)
                    .Select(p => p).FirstOrDefault();
                _bbContext.Interiorcategories.Remove(item);
                _bbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Interiorcategory> GetInteriorcategory(int InteriorcategoryId)
        {
            try
            {
                return _bbContext.Interiorcategories.AsQueryable().Where(sc => sc.Interiorcategoryid == InteriorcategoryId).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<Interiorcategory?> UpdateInteriorcategory(Interiorcategory request)
        {
            try
            {
                _bbContext.Interiorcategories.Update(request);
                _bbContext.SaveChanges();

                Interiorcategory? item = await _bbContext.Interiorcategories.OrderByDescending(sc => sc.Interiorcategoryid).FirstOrDefaultAsync();
                return item;
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
                return _bbContext.Interiorcategories.AsQueryable().Where(sc => sc.Subcategoryid == subcategoryId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<List<Interiorcategory>?> GetAllActiveInteriorcategories()
        {
            try
            {
                return _bbContext.Interiorcategories.Where(sc => sc.active == true).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
