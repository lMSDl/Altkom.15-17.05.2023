
using AutoMapper;
using DAL;
using DAL.DatabaseFirst;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Models;

var config = new MapperConfiguration(cfg =>

{
    cfg.CreateMap<DAL.DatabaseFirst.Product, Models.Product>().ForMember(x => x.Id, x => x.MapFrom(xx => 0));

    cfg.CreateMap<DAL.DatabaseFirst.Order, Models.Order>().ForMember(x => x.Id, x => x.MapFrom(xx => 0));
});
var mapper = new Mapper(config);


var optionsDb = new DbContextOptionsBuilder<MyDbContext>().UseSqlServer("Server=(local)\\SQLEXPRESS;Database=MyDb;Integrated security=true;Encrypt=false").Options;

/*using (var context = new MyDbContext(optionsDb))
{
    var user2 = new User { Username = "UserFirst", Password = "pasword", Type = "User" };
    var user3 = new User { Username = "AnonymouseFirst", Password = "pasword", Type = "Anonymouse" };

    context.Add(user2);
    context.Add(user3);

    context.SaveChanges();

}*/


var optionsCode = new DbContextOptionsBuilder<MyContext>().UseSqlServer("Server=(local)\\SQLEXPRESS;Database=MyDbCopy;Integrated security=true;Encrypt=false").Options;
using (var contextIn = new MyContext(optionsCode))
{
    contextIn.Database.EnsureDeleted();
    contextIn.Database.Migrate();
}


    using (var contextOut = new MyDbContext(optionsDb))
{

    using var transactionOut = contextOut.Database.BeginTransaction();

    using (var contextIn = new MyContext(optionsCode))
    {
        using var transactionIn = contextIn.Database.BeginTransaction();


        var orders = contextOut.Orders.ToList();
        contextOut.Products.Load();

        foreach (var order in orders)
        {
            var orderIn = mapper.Map<Models.Order>(order);
            contextIn.Add(orderIn);
        }

        contextIn.SaveChanges();



        contextOut.RemoveRange(orders);

        contextOut.SaveChanges();



        //throw new Exception();

        transactionIn.Commit();
    }

    transactionOut.Commit();

}


