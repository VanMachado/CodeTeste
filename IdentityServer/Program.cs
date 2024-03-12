using CodeChallenge.IdentityServer.Configuration;
using CodeChallenge.IdentityServer.Infra;
using CodeChallenge.IdentityServer.Infra.Context;
using CodeChallenge.IdentityServer.Initializer;
using CodeChallengeIdentityServer.Services;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<IdentityContext>(opt =>
    opt.UseMySql(builder.Configuration.GetConnectionString("MySqlContext"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MySqlContext"))));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityContext>()
    .AddDefaultTokenProviders();
builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;
    options.EmitStaticAudienceClaim = true;
}).AddInMemoryIdentityResources(IdentityConfiguration.IdentityResources)
  .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes)
  .AddInMemoryClients(IdentityConfiguration.Clients)
  .AddAspNetIdentity<ApplicationUser>()
  .AddDeveloperSigningCredential();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddScoped<IProfileService, ProfileService>();

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
app.UseIdentityServer();
app.UseAuthorization();

app.Services.CreateScope()
    .ServiceProvider.GetRequiredService<IDbInitializer>().Initialize();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
