using AutoMapper;
using CodeChallenge.Config;
using CodeChallenge.Data;
using CodeChallenge.Service;
using CodeChallenge.Service.IService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MySqlContext>(opt =>
    opt.UseMySql(builder.Configuration.GetConnectionString("MySqlContext"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MySqlContext"))));
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<IClientService, ClientService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.Services.CreateScope()
    .ServiceProvider.GetRequiredService<SeedingService>().Seed();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
