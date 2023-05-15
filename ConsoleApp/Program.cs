

using DAL;
using Microsoft.EntityFrameworkCore;
using Models;

//using (var context = new MyContext("Server=(local)\\SQLEXPRESS;Database=MyDb;User Id=sa;Password=pa$$w0rd"))
using (var context = new MyContext("Server=(local)\\SQLEXPRESS;Database=MyDb;Integrated security=true"))
//using (var context = new MyContext("Server=(localdb)\\mssqllocaldb;Database=MyDb;AttachDBFilename=c:\\EF6\\abc.mdf"))
{
    //var result = context.Database.EnsureDeleted();

}

var options = new DbContextOptionsBuilder().UseSqlServer("Server=(local)\\SQLEXPRESS;Database=MyDb;Integrated security=true").Options;

using (var context = new MyContext(options))
{
    //context.Database.EnsureCreated();
    context.Database.Migrate();

}