
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

        public int createCategory(CategoryForCreationDto categoryForCreationDto)
        {
            var categoriesEntityList = _repository.RepositoryCategory.GetAllCategories(false);
            
            foreach(var category in categoriesEntityList)
            {
                if (category.categoryName == categoryForCreationDto.categoryName) 
                    throw new CategoryNameAlreadyExistException(categoryForCreationDto.categoryName);
            }

            var categoryEntity = _mapper.Map<Category>(categoryForCreationDto);
            _repository.RepositoryCategory.CreateCategory(categoryEntity);
            _repository.Save();

            return categoryEntity.id;
        }

        public void deleteCategory(int categoryId)
        {
            var categoryEntity = _repository.RepositoryCategory.GetCategory(categoryId, trackChange: true);

            if(categoryEntity == null) throw new CategoryNotFoundException(categoryId);

            _repository.RepositoryCategory.DeleteCategory(categoryEntity);
            _repository.Save();
            
        }

        public IEnumerable<CategoryDto> getAllCategory(bool trackChange)
        {
            var categoriesEntityList = _repository.RepositoryCategory.GetAllCategories(trackChange);
            var categoriesDtoList = _mapper.Map<IEnumerable<CategoryDto>>(categoriesEntityList);
            return categoriesDtoList;
        }

        public CategoryDto getCategoryById(int id, bool trackChange)
        {
            var categoryEntity = _repository.RepositoryCategory.GetCategory(id, trackChange);
            if(categoryEntity == null)
            {
                throw new CategoryNotFoundException(id);
            }
            var categoryDto = _mapper.Map<CategoryDto>(categoryEntity);
            return categoryDto;
        }

        public void updateCategory(int categoryId, CategoryForUpdateDto categoryForUpdateDto)
        {
            var categoriesList = _repository.RepositoryCategory.GetAllCategories(trackChange: true);

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

        public IEnumerable<ProductDto> getProductsByCategoryId(int categoryId, bool trackChange) 
        {
            var categoriesEntityList = _repository.RepositoryCategory.GetAllCategories(trackChange);

            var productsEntityList = _repository.RepositoryProduct.GetProducts(trackChange);

            var usersEntityList = _repository.RepositoryUser.GetAllUsers(trackChange);

            var productsForRes = (from product in productsEntityList
                                    join category in categoriesEntityList
                                    on product.id equals category.id
                                    join user in usersEntityList
                                    on product.userId equals user.userId
                                    where category.id == categoryId
                                    orderby product.id ascending
                                    select new Product
                                    {
                                        id = product.id,
                                        productName = product.productName,
                                        description = product.description,
                                        price = product.price,
                                        active = product.active,
                                        Category = new Category
                                        {
                                            id = category.id,
                                            categoryName = category.categoryName
                                        },
                                        User = new User
                                        {
                                            fullname = user.fullname,
                                        }
                                    });

            var productsDtoList = _mapper.Map<IEnumerable<ProductDto>>(productsForRes);
            return productsDtoList;
        }
    }
}
