using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace PlaylistManagerApp.Data.Entities;

public class UserEntity : IdentityUser<int>
{
    [Required, MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    
    public DateTimeOffset RegistrationDate { get; set; }
}