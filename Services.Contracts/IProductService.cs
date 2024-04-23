using Shared.DataTransferObjects;

namespace Services.Contracts
{
    public interface IProductService
    {
        void CreateProduct(ProductForCreationDto productForCreation);

        IEnumerable<ProductDto> GetAllProducts(bool trackChange);

        ProductDto GetProduct(int id, bool trackChange);

        void UpdateProduct(ProductForUpdateDto productForUpdate);

        void DeleteProduct(int id);

        void UpdateProductStatus(int id, bool newStatus);
    }
}
