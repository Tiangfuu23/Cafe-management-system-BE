using Entities.DataTransferObjects;

namespace Shared.DataTransferObjects
{
    public record ProductDto(int id, string productName, string description, float price,
                                int status, bool active ,CategoryDto category, string creator);
}
