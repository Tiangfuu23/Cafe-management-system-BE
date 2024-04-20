
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Services.Contracts;
using Shared.DataTransferObjects;

namespace Services
{
    internal class CategoryService : ICategoryService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public CategoryService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {

            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        public void createCategory(CategoryForCreationDto categoryForCreationDto)
        {
            var categoriesEntityList = _repository.RepositoryCategory.getAllCategories(false);
            
            foreach(var category in categoriesEntityList)
            {
                if (category.categoryName == categoryForCreationDto.categoryName) 
                    throw new CategoryNameAlreadyExistException(categoryForCreationDto.categoryName);
            }

            var categoryEntity = _mapper.Map<Category>(categoryForCreationDto);
            _repository.RepositoryCategory.createCategory(categoryEntity);
            _repository.Save();
        }

        public void deleteCategory(int categoryId)
        {
            var categoryEntity = _repository.RepositoryCategory.getCategory(categoryId, trackChange: true);

            if(categoryEntity == null) throw new CategoryNotFoundException(categoryId);

            _repository.RepositoryCategory.deleteCategory(categoryEntity);
            _repository.Save();
            
        }

        public IEnumerable<CategoryDto> getAllCategory(bool trackChange)
        {
            var categoriesEntityList = _repository.RepositoryCategory.getAllCategories(trackChange);
            var categoriesDtoList = _mapper.Map<IEnumerable<CategoryDto>>(categoriesEntityList);
            return categoriesDtoList;
        }

        public CategoryDto getCategoryById(int id, bool trackChange)
        {
            var categoryEntity = _repository.RepositoryCategory.getCategory(id, trackChange);
            if(categoryEntity == null)
            {
                throw new CategoryNotFoundException(id);
            }
            var categoryDto = _mapper.Map<CategoryDto>(categoryEntity);
            return categoryDto;
        }

        public void updateCategory(int categoryId, CategoryForUpdateDto categoryForUpdateDto)
        {
            var categoriesList = _repository.RepositoryCategory.getAllCategories(trackChange: true);

            int idxOfCategoryForUpdate = -1;
            for(int i = 0; i<categoriesList.Count(); i++)
            {
                if(categoriesList.ElementAt(i).categoryName == categoryForUpdateDto.categoryName) 
                    throw new CategoryNameAlreadyExistException(categoryForUpdateDto.categoryName);

                if (categoriesList.ElementAt(i).id == categoryId) idxOfCategoryForUpdate = i;
            }
            
            if(idxOfCategoryForUpdate == -1) throw new CategoryNotFoundException(categoryId);

            _mapper.Map(categoryForUpdateDto, categoriesList.ElementAt(idxOfCategoryForUpdate));

            _repository.Save();
        }
    }
}
