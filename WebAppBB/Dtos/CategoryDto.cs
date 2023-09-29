namespace WebAppBB.Dtos
{
    public class CategoryDto : InteriorCategoryDto
    {
        public List<SubCategoryDto> Subcategories{ get; set; }
    }
}
