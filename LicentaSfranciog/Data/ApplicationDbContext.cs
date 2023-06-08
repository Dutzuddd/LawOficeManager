using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LicentaSfranciog.Models;
using LicentaSfranciog.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Logging;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("ApplicationDbContext");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    public DbSet<LicentaSfranciog.Models.Client> Client { get; set; } = default!;

    public DbSet<LicentaSfranciog.Models.Proces>? Proces { get; set; }
    public DbSet<Eveniment> Evenimente { get; set; }
    public DbSet<Loc> Locatii { get; set; }

}
