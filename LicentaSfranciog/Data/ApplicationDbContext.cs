using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LicentaSfranciog.Models;

    public class ApplicationDbContext : DbContext
    {
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
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
    }
