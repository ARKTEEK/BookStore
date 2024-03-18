using Blazored.Toast;
using BlazorServer.Auth;
using DataLibrary;
using DataLibrary.Repositories;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthenticationCore();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredToast();

string? connectionString =
  builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContextFactory<DataContext>(options =>
  options.UseMySql(connectionString,
    ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<ProtectedSessionStorage>();

builder.Services.AddScoped<AuthorRepository>();
builder.Services.AddScoped<BookRepository>();
builder.Services.AddScoped<BookTypeRepository>();
builder.Services.AddScoped<CartItemRepository>();
builder.Services.AddScoped<CartRepository>();
builder.Services.AddScoped<DiscountRepository>();
builder.Services.AddScoped<GenreRepository>();
builder.Services.AddScoped<RoleRepository>();
builder.Services.AddScoped<UserRepository>();

builder.Services
  .AddScoped<AuthenticationStateProvider, AuthenticationProvider>();
WebApplication app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();