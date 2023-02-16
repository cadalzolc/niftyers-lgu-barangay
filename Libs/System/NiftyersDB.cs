using Microsoft.EntityFrameworkCore;

namespace Niftyers;

public class NiftyersDB : DbContext {
    
    protected readonly IConfig config;
    public NiftyersDB(IConfig _config) {
        config = _config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) {
        options.UseMySql(config.MySql, ServerVersion.AutoDetect(config.MySql));
    }

    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder) {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new User.Configuration());
    }

}