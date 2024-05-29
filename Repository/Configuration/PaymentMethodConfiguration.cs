using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public PaymentMethodConfiguration()
        {
            
        }
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasData(
                new PaymentMethod
                {
                    id = 1,
                    description = "Cash"
                },
                new PaymentMethod
                {
                    id = 2,
                    description = "Bank"
                },
                new PaymentMethod
                {
                    id = 3,
                    description = "Creadit card"
                }
            );
        }
    }
}
