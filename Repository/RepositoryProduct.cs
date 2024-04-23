using Contracts;
using Entities.Models;

namespace Repository
{
    internal class RepositoryProduct : RepositoryBase<Product>, IRepositoryProduct
    {
        public RepositoryProduct(RepositoryContext repositoryContext) :  base(repositoryContext)
        {
            
        }
        public void CreateProduct(Product product)
        {
            Create(product);
        }

        public void DeleteProduct(Product product)
        {
            Delete(product);
        }
        public void UpdateProduct(Product product)
        {
            Update(product);
        }

        public Product? GetProduct(int id, bool trackChange)
        {
            return FindByCondition(p => p.id == id, trackChange).SingleOrDefault();
        }

        public IEnumerable<Product> GetProducts(bool trackChange)
        {
            return FindAll(trackChange).OrderBy(p => p.id).ToList();
            
        }

    }
}
