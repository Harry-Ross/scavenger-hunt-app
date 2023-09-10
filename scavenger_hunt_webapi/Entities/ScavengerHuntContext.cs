using Microsoft.EntityFrameworkCore;

namespace scavenger_hunt_webapi.Entities;
public class ScavengerHuntContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Post> Posts { get; set; }

    public ScavengerHuntContext(DbContextOptions<ScavengerHuntContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasAlternateKey(user => user.Guid);
            entity.Property(user => user.Guid).HasDefaultValue(new Guid());

            entity.Property(user => user.Created).ValueGeneratedOnAdd();
            entity.Property(user => user.Updated).ValueGeneratedOnAdd();

            entity.HasMany(user => user.Posts)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .IsRequired();

            entity.HasMany(user => user.Teams)
                .WithMany(e => e.Users);
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasAlternateKey(team => team.Guid);
            entity.HasOne(team => team.Owner).WithMany(user => user.OwnedTeams);
            entity.HasOne(team => team.Game).WithMany(game => game.Teams);
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

            entity.HasOne(post => post.Game)
                .WithMany(game => game.Posts)
                .HasForeignKey(post => post.GameId)
                .IsRequired();
        });
    }
}
