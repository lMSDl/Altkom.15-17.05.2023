using DAL;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.DAL;
using Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<DbContext, MyContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbConnectionString"))

                                                                      // wy³¹czenie œledzenia encji (globalne)
                                                                      .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution));

builder.Services.AddScoped<IService<Person>, Service<Person>>();
builder.Services.AddScoped<IService<Company>, Service<Company>>();


var app = builder.Build();

using (var scope = app.Services.CreateScope()) { 
     scope.ServiceProvider.GetService<DbContext>()!.Database.EnsureCreated();
}

app.MapControllers();

app.Run();
