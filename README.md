# PhoneService_API

Create appsettings.json with connectionString to Database and secret key for JWT Auth

```
{
   "Logging": {
       "LogLevel": {
           "Default": "Information",
           "Microsoft": "Warning",
           "Microsoft.Hosting.Lifetime": "Information"
       },
       "AllowedHosts": "*",
       "ConnectionStrings": {
           "ServiceApi": "Data Source=DATABASESERVER;Initial Catalog=DATABASECATALOG;User ID=USERID;Password=****;Connect Timeout=30"
       }
       "AppSetings": {
           "Secret": "YOUR SECRET KEY"
       }
   }
}
```
