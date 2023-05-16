

using DAL;
using Microsoft.EntityFrameworkCore;
using Models;

//using (var context = new MyContext("Server=(local)\\SQLEXPRESS;Database=MyDb;User Id=sa;Password=pa$$w0rd"))
using (var context = new MyContext("Server=(local)\\SQLEXPRESS;Database=MyDb;Integrated security=true;Encrypt=false"))
//using (var context = new MyContext("Server=(localdb)\\mssqllocaldb;Database=MyDb;AttachDBFilename=c:\\EF6\\abc.mdf"))
{
    var result = context.Database.EnsureDeleted();

}

var options = new DbContextOptionsBuilder().UseSqlServer("Server=(local)\\SQLEXPRESS;Database=MyDb;Integrated security=true;Encrypt=false")
    .LogTo(Console.WriteLine)
    /*.UseLazyLoadingProxies()*/.Options;





IEnumerable<StandaloneAddress> values;
using (var context = new MyContext(options))
{
    //context.Database.EnsureCreated();
    context.Database.Migrate();


    /*   var item = new StandaloneAddress() { City = "a", Street = "a", ZipCode = "11" };
       item.Location = new Location() { Latitude = 10, Longitude = 20 };


       context.Add(item);
       context.SaveChanges();*/


    values = context.Set<StandaloneAddress>().ToList();

    /*values.First().City = "1";
    if (values.First().Location != null)
        ;*/

}


using (var context = new MyContext(options))
{
    //var user1 = new User { Username = "Admin", Password = "pasword", Type = UserTypes.Admin };
    var user2 = new User { Username = "User", Password = "pasword", Type = UserTypes.User };
    var user3 = new User { Username = "Anonymouse", Password = "pasword", Type = UserTypes.Anonymouse };

    //context.Add(user1);
    context.Add(user2);
    context.Add(user3);

    context.SaveChanges();

}




    Console.WriteLine();


