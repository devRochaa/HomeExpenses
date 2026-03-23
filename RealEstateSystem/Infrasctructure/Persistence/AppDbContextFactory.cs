using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RealEstateSystem.Infrasctructure.Persistence;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer(
            connectionString: "Server=(localdb)\\mssqllocaldb;Database=RealEstateSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        
        return new AppDbContext(optionsBuilder.Options);
    }
}
