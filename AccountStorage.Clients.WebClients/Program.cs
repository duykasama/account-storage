using AccountStorage.Clients.WebClients.Areas.Identity;
using AccountStorage.Clients.WebClients.Flux;
using AccountStorage.Clients.WebClients.Flux.Dispatcher;
using AccountStorage.Clients.WebClients.Flux.Interfaces;
using AccountStorage.Clients.WebClients.Flux.Stores.AccountStore;
using AccountStorage.Clients.WebClients.Flux.Stores.AccountStore.Actions;
using AccountStorage.Clients.WebClients.Flux.Stores.CategoryStore;
using AccountStorage.Clients.WebClients.Flux.Stores.CounterStore;
using AccountStorage.Clients.WebClients.Flux.Stores.PlatformStore;
using AccountStorage.Clients.WebClients.Flux.Stores.SystemUserStore;
using AccountStorage.Service.Entities;
using AccountStorage.Service.Services;
using AccountStorage.Service.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AccountDbContext>(options =>
{
    options.UseSqlServer(connectionString);
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

//builder.Services.AddDbContextFactory<AccountDbContext>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddIdentity<SystemUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AccountDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<SystemUser>>();
builder.Services.AddScoped<IActionDispatcher<IAction>, ActionDispatcher>();
builder.Services.AddTransient<AccountDbContext>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IPlatformService, PlatformService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISystemUserService, SystemUserService>();
builder.Services.AddScoped<AccountStore>();
builder.Services.AddScoped<PlatformStore>();
builder.Services.AddScoped<CategoryStore>();
builder.Services.AddScoped<SystemUserStore>();
builder.Services.AddScoped<CounterStore>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
