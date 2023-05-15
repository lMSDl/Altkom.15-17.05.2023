* Pakiety
```
Microsoft.EntityFrameworkCore.SqlServer - dostawca bazy danych
Microsoft.EntityFrameworkCore.Design - umożliwia migracje
Microsoft.EntityFrameworkCore.Tools - umożliwia migracje w PMC
```

* dotnet-ef (CLI)
```
dotnet tool install --global dotnet-ef [--version 6.0.16]
dotnet tool uninstall --global dotnet-ef
```

* Migracje
   * CLI
   ```
   dotnet ef migrations add <nazwa>
   dotnet ef migrations remove [-f]
   
   dotnet ef database update [--connection "<connection string>"] 
   ```
   
   * Package Manager Console
   ```
   Add-Migration <nazwa>
   Remove-Migration [-f]
   
   Update-Database [-connection "<conneciton string>"]
   ```

* ConnectionString dla MSSQL
```
Server=(localdb)\mssqllocaldb;Database=<name>;[AttachDBFilename=<file path>]
Sercer=(local);Database=<name>;Integrated security=true
Sercer=<ip>;Database=<name>;User Id=<user>;Password=<password>
Sercer=(local)\SQLExpress;Database=<name>;Integrated security=true
```
