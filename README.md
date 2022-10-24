# PhoneService_API

Create appsettings.json with connectionString to Database and secret key for JWT Auth

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "AppSettings": {
    "Secret": "Generate example secret key"
  },
  "ConnectionStrings": {
    "PostgresSql": "Host=127.0.0.1;Port=5432;Database=DATABASE;Username=Username;Password=****",
    "MSSQL": "Data Source=DATABASESERVER;Initial Catalog=DATABASECATALOG;User ID=USERID;Password=****;Connect Timeout=30"
  }
}

```
