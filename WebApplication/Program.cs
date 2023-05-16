using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Models.Inheritance;
using Services.DAL;
using Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<DbContext, MyContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbConnectionString"))
                                                                      // wy³¹czenie œledzenia encji (globalne)
                                                                      .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution));

builder.Services.AddScoped<IService<Person>, Service<Person>>();
builder.Services.AddScoped<IService<Company>, Service<Company>>();
builder.Services.AddScoped<IService<SmallCompany>, Service<SmallCompany>>();
builder.Services.AddScoped<IService<LargeCompany>, Service<LargeCompany>>();
builder.Services.AddScoped<IService<Educator>, Service<Educator>>();
builder.Services.AddScoped<IService<Student>, Service<Student>>();
builder.Services.AddScoped<IService<StandaloneAddress>, Service<StandaloneAddress>>();

var app = builder.Build();

using (var scope = app.Services.CreateScope()) { 
     scope.ServiceProvider.GetService<DbContext>()!.Database.Migrate();
}

app.MapControllers();

app.Run();
