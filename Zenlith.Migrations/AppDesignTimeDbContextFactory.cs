using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Zenlith.App.Module.BusinessObjects;

namespace Zenlith.Migrations;

public class AppDesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppEFCoreDbContext>
{
    public AppEFCoreDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppEFCoreDbContext>();
        string connStr = args.Length==1?args[0]:"";
        optionsBuilder.UseSqlServer(connStr, b => b.MigrationsAssembly("Zenlith.Migrations"));
        return new AppEFCoreDbContext(optionsBuilder.Options);
    }
}