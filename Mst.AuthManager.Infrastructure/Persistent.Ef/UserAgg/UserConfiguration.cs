using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mst.AuthManager.Domain.UserAgg;

namespace Mst.AuthManager.Infrastructure.Persistent.Ef.UserAgg;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users", "user");

        builder.HasIndex(x => x.Username).IsUnique();

        builder.Property(b => b.Username).IsRequired().HasMaxLength(400);

        builder.Property(b => b.Password).IsRequired().HasMaxLength(150);

        builder.OwnsMany(x => x.Tokens, option =>
        {
            option.ToTable("Tokens", "user");
            option.HasKey(b => b.Id);
            option.Property(x => x.HashJwtToken).IsRequired().HasMaxLength(250);
            option.Property(x => x.HashRefreshToken).IsRequired().HasMaxLength(250);
            option.Property(x => x.Device).IsRequired().HasMaxLength(100);
        });

        builder.OwnsMany(x => x.Roles, option =>
        {
            option.ToTable("Roles", "user");
            option.HasIndex(x => x.UserId);
        });

    }
}
