using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            
        }
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role
                {
                    roleId = 1,
                    description = "Admin",
                },
                new Role
                {
                    roleId = 2,
                    description = "Manager",
                },
                new Role
                {
                    roleId = 3,
                    description = "Staff"
                }
                ); ;
        }
    }
}
