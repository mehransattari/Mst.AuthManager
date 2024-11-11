using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mst.AuthManager.Domain.RoleAgg;

namespace Mst.AuthManager.Infrastructure.Persistent.Ef.RoleAgg;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles", "role");

        builder.Property(x => x.Title).IsRequired().HasMaxLength(150);

        builder.OwnsMany(x => x.Permissions, option =>
        {
            option.ToTable("Permissions", "role");
        });
    }
}
