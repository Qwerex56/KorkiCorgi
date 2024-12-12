using KorkiCorgi.Models.TypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace KorkiCorgi.Models;

public class CorgiDbContext : DbContext {
    
    public DbSet<TutorUser> TutorUsers { get; set; }
    public DbSet<StudentUser> StudentUsers { get; set; }
    public DbSet<AccountInformation> AccountInformations { get; set; }
    public DbSet<AccountStatistics> AccountStatistics { get; set; }
    public DbSet<EducationMaterial> EducationMaterials { get; set; }
    public DbSet<WeekCalendar> WeekCalendars { get; set; }
    public DbSet<WeekCalendarDayData> WeekCalendarDayData { get; set; }
    
    public CorgiDbContext(DbContextOptions<CorgiDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        base.OnConfiguring(optionsBuilder);
    }
}