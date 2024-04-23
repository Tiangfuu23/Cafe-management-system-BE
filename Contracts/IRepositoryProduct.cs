using Entities.Models;

namespace Contracts
{
    public interface IRepositoryProduct
    {
        IEnumerable<Product> GetProducts(bool trackChange);

        Product? GetProduct(int id, bool trackChange);

        void CreateProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(Product product);
    }
}
