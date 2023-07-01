using Microsoft.EntityFrameworkCore;

namespace scavenger_hunt_webapi.Models;
public class ScavengerHuntContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasAlternateKey(user => user.Guid);
            entity.Property(user => user.Created).ValueGeneratedOnAdd();
            entity.Property(user => user.Updated).ValueGeneratedOnAddOrUpdate();

            entity.HasMany(user => user.Posts)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .IsRequired();

            entity.HasMany(user => user.Teams)
                .WithMany(e => e.Users);
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasMany(team => team.Users).WithMany(user => user.Teams);
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasMany(game => game.Teams)
                .WithOne(team => team.Game)
                .HasForeignKey(team => team.GameId)
                .IsRequired();

            entity.HasMany(game => game.Users).WithMany(user => user.Games);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasOne(post => post.User)
                .WithMany(entity => entity.Posts)
                .HasForeignKey(post => post.UserId)
                .IsRequired();
        });
    }
}
