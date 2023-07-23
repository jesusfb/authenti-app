##### Install packages
- Microsoft.AspNetCore.Authentication.JwtBearer
- Microsoft.AspNetCore.Identity
- Microsoft.AspNetCore.Identity.EntityFramework
- Microsoft.EntityFrameworkCore.Tools

---

#### UseSqlServer
- To use `UseSqlServer` you need a plugin
- Microsoft.EntityFrameworkCore.SqlServer

##### Run MSSQL using Docker
- docker run -e "ACCEPT_EULA=1" -e "MSSQL_SA_PASSWORD=*********" -e "MSSQL_PID=Developer" -e "MSSQL_USER=SA" -p 1433:1433 -d --name=sql mcr.microsoft.com/azure-sql-edge

##### Go to Azure Data studio and create a new connction string
- Click on new connection
- Server: localhost
- Username: SA
- Password: ********
- Authentication type: SQL Login
Then click connect

####### Create a new database
- On the new connection, right click and select `New Query`
- Create a new Database
```sql
CREATE DATABASE ApiAuth;
```

###### Set the database connection string in your appsettings.json
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "ConnStr": "Server=localhost,1433;Database=ApiAuth;User Id=SA;Password=***********;Encrypt=false;TrustServerCertificate=True;"
  },
  "JWT": {
    "ValidAudience": "User",
    "ValidIssuer": "http://localhost:61955",
    "Secret": "d9c34e3de1c0473a37d9cc96f9bffe846c1fe7dd6d7317c8f487b6764e7fc88e"
  }
}

```

##### Run migration using the ef dotnet commands, run simultaneously
```bash
dotnet ef migrations add InitialCreate --context ApplicationDbContext
dotnet ef database update -c ApplicationDbContext
```

If you edit your model, to update the migration use
```bash
dotnet ef migrations add "Your Preferred name"" --context ApplicationDbContext

dotnet ef migrations add NewChanges --context ApplicationDbContext
Then:
dotnet ef database update -c ApplicationDbContext

```

---

#### Getting errors like
- PasswordRequiresNonAlphanumeric,PasswordRequiresDigit,PasswordRequiresUpper
Use payload like:

```json
{
  "username": "abababab",
  "email": "ab@gmail.com",
  "password": "BassGuitar1!"
}
```

---

#### If you get Failed to load API definition.
It means the route http Verb is not set properly

Note: Your secret key should be 16 characters minimum


---

##### You can add packages using the .NET CLI
> dotnet add package DotNetEnv
