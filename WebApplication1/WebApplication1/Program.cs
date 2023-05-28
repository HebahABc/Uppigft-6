using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Contexts;
using WebApplication1.Factories;
using WebApplication1.Helpers.Repositories;
using WebApplication1.Helpers.Services;
using WebApplication1.Models.Entities;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();


//Contexts
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("sql")));

//Authentication
builder.Services.AddIdentity<UserEntity, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<DataContext>()
    .AddClaimsPrincipalFactory<CustomClaimsPrinipalFactory>();

//Repositories
builder.Services.AddScoped<AddressRepo>();
builder.Services.AddScoped<UserAddressRepo>();
builder.Services.AddScoped<ContactRepo>();
builder.Services.AddScoped<ProductRepo>();
builder.Services.AddScoped<TagRepo>();
builder.Services.AddScoped<ProductTagRepo>();


//Services
builder.Services.AddScoped<ProductServices>();
builder.Services.AddScoped<AdminServices>();
builder.Services.AddScoped<AccountServices>();
builder.Services.AddScoped<TagServices>();
builder.Services.AddScoped<AddressServices>();


builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/Signin";
    x.LogoutPath = "/";
    x.AccessDeniedPath = "/Denied";
});



var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
