using DevExpress.ExpressApp.EFCore.Updating;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EFCore.DesignTime;
using Zenlith.Model;

namespace Zenlith.App.Module.BusinessObjects;

// // This code allows our Model Editor to get relevant EF Core metadata at design time.
// // For details, please refer to https://supportcenter.devexpress.com/ticket/details/t933891.
// public class AppContextInitializer : DbContextTypesInfoInitializerBase {
// 	protected override DbContext CreateDbContext() {
// 		var optionsBuilder = new DbContextOptionsBuilder<AppEFCoreDbContext>();
// 		optionsBuilder.UseSqlServer("Integrated Security=false;Pooling=false;Data Source=.;Initial Catalog=zenlith;User ID=zenlith;Password=zenlith;TrustServerCertificate=True");
//         return new AppEFCoreDbContext(optionsBuilder.Options);
// 	}
// }
//This factory creates DbContext for design-time services. For example, it is required for database migration.

// [TypesInfoInitializer(typeof(AppContextInitializer))]
public class AppEFCoreDbContext : ZenlithContext {
	public AppEFCoreDbContext(DbContextOptions options) : base(options) {
	}
	//public DbSet<ModuleInfo> ModulesInfo { get; set; }
	public DbSet<ModelDifference> ModelDifferences { get; set; }
	public DbSet<ModelDifferenceAspect> ModelDifferenceAspects { get; set; }
	public DbSet<PermissionPolicyRole> Roles { get; set; }
	public DbSet<Zenlith.App.Module.BusinessObjects.ApplicationUser> Users { get; set; }
    public DbSet<Zenlith.App.Module.BusinessObjects.ApplicationUserLoginInfo> UserLoginInfos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Zenlith.App.Module.BusinessObjects.ApplicationUserLoginInfo>(b => {
            b.HasIndex(nameof(DevExpress.ExpressApp.Security.ISecurityUserLoginInfo.LoginProviderName), nameof(DevExpress.ExpressApp.Security.ISecurityUserLoginInfo.ProviderUserKey)).IsUnique();
        });
    }
}
