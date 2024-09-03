# 🌡️ weather-app

Repo of the weather-app

## 🧪 Usage

To use the weather app:

### 🌐 From browser:
  1. To get current weather data make a request to: https://apim-weatherapp-dev.azure-api.net/get-weather-data?city=pancevo
  2. To get historical weather data make a request to: https://apim-weatherapp-dev.azure-api.net/get-historical-weather-data?city=pancevo&date=2023-01-01

### ✉️ From postman:
  1. Import the "WeatherApp.postman_collection.json" collection from the repository
  2. Clone the repository
  3. Add weatherstack api key in local.settings.json
  4. Trigger request "get-weather-from-local-app

## 📔 About the app
  - App is created using .NET 8.0, everything is hosted on azure.
  - CI/CD pipeline deploys the application to the azure function on push, using github actions.

## 📝 Template for local.settings.json

```json
{
    "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
    "WEATHERSTACK_ACCESS_KEY": "get the API key from https://weatherstack.com/"
  }
}
```
