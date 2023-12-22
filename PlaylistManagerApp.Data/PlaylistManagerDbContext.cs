using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlaylistManagerApp.Data.Entities;

namespace PlaylistManagerApp.Data;

public class PlaylistManagerDbContext : IdentityDbContext<UserEntity, IdentityRole<int>, int>
{
    public PlaylistManagerDbContext(DbContextOptions<PlaylistManagerDbContext> options)
        : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserEntity>().ToTable("Users");
    }

    public DbSet<SongEntity> Songs { get; set; }
    public DbSet<PlaylistEntity> Playlists { get; set; }
    public DbSet<PlaylistSongEntity> PlaylistSongs { get; set; }
    public DbSet<SongRatingEntity> Ratings { get; set; }
}