using Microsoft.EntityFrameworkCore;

namespace PlaylistManagerApp.Data;

public class PlaylistManagerDbContext : DbContext
{
    public PlaylistManagerDbContext(DbContextOptions<PlaylistManagerDbContext> options)
        : base(options) {}
}