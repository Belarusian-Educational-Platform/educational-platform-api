<h1 align='center'>educational-platform-api</h1>

<h2 align='center'>Configuring</h2>

appsetting.json
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost; port=3306; database=educational-platform; user=root; password=daniil;"
  },
  "AllowedHosts": "*",
  "Keycloak": {
    "realm": "educational-platform",
    "auth-server-url": "http://localhost:8080/",
    "ssl-required": "external",
    "resource": "educational-platform-api",
    "public-client": true,
    "confidential-port": 0,
    "verify-token-audience": false
  }
}
```
