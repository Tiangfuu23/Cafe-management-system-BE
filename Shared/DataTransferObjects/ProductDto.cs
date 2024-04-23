using Entities.DataTransferObjects;

namespace Shared.DataTransferObjects
{
    public record ProductDto(int id, string productName, string description, float price,
                                bool status, CategoryDto category, string creator);
}
