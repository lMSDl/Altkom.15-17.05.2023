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

builder.Services.AddDbContextPool<DbContext, MyContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbConnectionString"))
                                                                       /*.UseLazyLoadingProxies()*/
                                                                       .LogTo(x => Console.WriteLine(x)), poolSize: 32);
                                                                      // wy³¹czenie œledzenia encji (globalne)
                                                                      //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution));

builder.Services.AddScoped<IService<Person>, Service<Person>>();
builder.Services.AddScoped<IService<Company>, CompaniesService>();
builder.Services.AddScoped<IService<SmallCompany>, Service<SmallCompany>>();
builder.Services.AddScoped<IService<LargeCompany>, Service<LargeCompany>>();
builder.Services.AddScoped<IService<Educator>, Service<Educator>>();
builder.Services.AddScoped<IService<Student>, Service<Student>>();
builder.Services.AddScoped<IService<StandaloneAddress>, StandaloneAddressesService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope()) { 
     scope.ServiceProvider.GetService<DbContext>()!.Database.Migrate();
}

app.MapControllers();

app.Run();
