using Microsoft.EntityFrameworkCore;
using WebAppBB.Dtos;
using WebAppBB.Models;

namespace WebAppBB.Repositories
{
    public class CategoriesRepository
    {
        private readonly BbContext _bbContext;
        public CategoriesRepository(BbContext bbContext)
        {
            _bbContext = bbContext;
        }

        public async Task<Category?> SaveCategory(Category request)
        {
            try
            {
                _bbContext.Categories.Add(request);
                _bbContext.SaveChanges();

                Category? item = await _bbContext.Categories.OrderByDescending(c => c.Categoryid).FirstOrDefaultAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteCategory(int CategoryId)
        {
            try
            {

                Category? item = _bbContext.Categories.AsQueryable().Where(sc => sc.Categoryid == CategoryId).Select(p => p).FirstOrDefault();
                _bbContext.Categories.Remove(item);
                _bbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Category> GetCategory(int CategoryId)
        {
            try
            {
                return _bbContext.Categories.AsQueryable().Where(sc => sc.Categoryid == CategoryId).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<Category?> UpdateCategory(Category request)
        {
            try
            {
                _bbContext.Categories.Update(request);
                _bbContext.SaveChanges();

                Category? item = await _bbContext.Categories.OrderByDescending(sc => sc.Categoryid).FirstOrDefaultAsync();
                return item;
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
                return _bbContext.Categories.ToList();
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
                ContentCategoriesResponse result = new ContentCategoriesResponse();
                List<CategoryDto> categories = _bbContext.Categories
                    .Select(ct => new CategoryDto {
                        id = ct.Categoryid,
                        name = ct.Description
                    }).ToList();
                foreach (CategoryDto c in categories) {
                    c.Subcategories = _bbContext.Subcategories.Where(sc => sc.Categoryid == c.id)
                    .Select(sct => new SubCategoryDto
                    {
                        id = sct.Subcategoryid,
                        name = sct.Description
                    }).ToList();

                    foreach (SubCategoryDto sc in c.Subcategories)
                    {
                        sc.interiorCategories = _bbContext.Interiorcategories.Where(ic => ic.Subcategoryid == sc.id)
                            .Select(ict => new InteriorCategoryDto
                            {
                                id = ict.Interiorcategoryid,
                                name = ict.Description
                            }).ToList();
                    }
                }
                
                result.categories = categories;
                return result;                                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
