
using Shared.DataTransferObjects;

namespace Services.Contracts
{
    public interface ICategoryService
    {
       IEnumerable<CategoryDto> getAllCategory(bool trackChange);

        CategoryDto getCategoryById(int id, bool trackChange);

        void createCategory(CategoryForCreationDto categoryForCreationDto);

        void updateCategory(int categoryId, CategoryForUpdateDto categoryForUpdateDto);

        void deleteCategory(int categoryId);
    }
}
