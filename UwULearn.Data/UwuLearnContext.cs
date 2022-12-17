using Microsoft.EntityFrameworkCore;
using UwULearn.Data.Entities;

namespace UwULearn.Data;

public class UwuLearnContext : DbContext
{
    public DbSet<AllChatMessage> AllChatMessages { get; set; }
    public DbSet<Cat> Cats { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Skin> Skins { get; set; }
    public DbSet<User> Users { get; set; }

    public UwuLearnContext(DbContextOptions<UwuLearnContext> options) 
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AllChatMessage>(entity =>
        {
            entity.ToTable(nameof(AllChatMessage));

            entity.HasKey(a => a.Id);

            entity.HasOne(a => a.From);
        });

        modelBuilder.Entity<Cat>(entity =>
        {
            entity.ToTable(nameof(Cat));

            entity.HasKey(c => c.Id);

            entity.HasOne(c => c.Skin);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.ToTable(nameof(Course));

            entity.HasKey(c => c.Id);

            entity.HasMany(c => c.Lessons);
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.ToTable(nameof(Lesson));

            entity.HasKey(l => l.Id);
        });

        modelBuilder.Entity<Skin>(entity =>
        {
            entity.ToTable(nameof(Skin));

            entity.HasKey(s => s.Id);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable(nameof(User));

            entity.HasKey(u => u.Id);

            entity.HasOne(u => u.Cat);
            entity.HasMany(u => u.Courses);            
        });
    }
}