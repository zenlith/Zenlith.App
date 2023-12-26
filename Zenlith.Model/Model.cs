using Microsoft.EntityFrameworkCore;

namespace Zenlith.Model;

public class ZenConfig
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Configuration { get; set; }
}

public class ZenlithContext: DbContext 
{
    public ZenlithContext(DbContextOptions options): base(options)
    {
    }
            
    public DbSet<ZenConfig> Grades { get; set; }
}