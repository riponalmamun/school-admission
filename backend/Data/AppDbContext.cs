using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Models;

namespace SchoolAdmission.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<ClassRoom> Classes => Set<ClassRoom>();
    public DbSet<Hold> Holds => Set<Hold>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<ClassRoom>(e =>
        {
            e.ToTable("classes");
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).IsRequired().HasMaxLength(200);
        });

        b.Entity<Hold>(e =>
        {
            e.ToTable("holds");
            e.HasKey(x => x.Id);
            e.Property(x => x.StudentId).IsRequired().HasMaxLength(17);
            e.Property(x => x.Status).IsRequired().HasMaxLength(20);
            e.HasIndex(x => new { x.ClassId, x.StudentId });
            e.HasIndex(x => new { x.ClassId, x.Status, x.ExpiresAt });
        });
    }
}