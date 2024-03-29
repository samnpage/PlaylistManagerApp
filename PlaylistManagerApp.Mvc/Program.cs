using Microsoft.EntityFrameworkCore;
using PlaylistManagerApp.Data;
using PlaylistManagerApp.Data.Entities;
using PlaylistManagerApp.Services.Playlist;
using PlaylistManagerApp.Services.PlaylistSong;
using PlaylistManagerApp.Services.Search;
using PlaylistManagerApp.Services.Song;
using PlaylistManagerApp.Services.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// DbContext configuration, adds the DbContext for dependency injection
builder.Services.AddDbContext<PlaylistManagerDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddHttpClient<ISearchService, SearchService>();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddScoped<ISearchService, SearchService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPlaylistService, PlaylistService>();
builder.Services.AddScoped<ISongService, SongService>();
builder.Services.AddScoped<IPlaylistSongService, PlaylistSongService>();

// Enable using Identity Managers (Users, SignIn, Password)
builder.Services.AddDefaultIdentity<UserEntity>()
    .AddEntityFrameworkStores<PlaylistManagerDbContext>();

// Configure what happens when a logged out user tries to access an authorized route
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
