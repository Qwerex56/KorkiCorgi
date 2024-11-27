using Microsoft.EntityFrameworkCore;

namespace KorkiCorgi.Models;

public class CorgiDbContext : DbContext {
    #region DbSets

    public DbSet<object> DummySet { get; set; }

    #endregion
    
    
    public CorgiDbContext(DbContextOptions<CorgiDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
    }
}