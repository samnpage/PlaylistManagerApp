using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;

namespace PlaylistManagerApp.Data.Entities;

public class PlaylistSongEntity
{
    [Key]
    public int PlaylistSongId { get; set; }

    [ForeignKey(nameof(Playlist))]
    public int PlaylistId { get; set; }
    public virtual PlaylistEntity Playlist { get; set; } = null!;

    [ForeignKey(nameof(Song))]
    public int SongId { get; set; }
    public virtual SongEntity Song { get; set; } = null!;

    public int Position { get; set; }
}