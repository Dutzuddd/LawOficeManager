using LicentaSfranciog.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LicentaSfranciog.Areas.Identity.Data;

public class UserDbContext : IdentityDbContext<ApplicationUser>
{
    public UserDbContext(DbContextOptions<UserDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Adding custom registration
        builder.ApplyConfiguration(new ApplicationUserEntity());

    }
}

internal class ApplicationUserEntity : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
       // Max. character length for Nume and Prenume
       builder.Property(u  => u.Nume).HasMaxLength(35);
       builder.Property(u => u.Prenume).HasMaxLength(35);
    }
}