# 🌡️ weather-app

Repo of the weather-app

## 🧪 Testing

To use the weather app:

### 🌐 From browser:
  1. Make a request to: https://apim-weatherapp-dev.azure-api.net/get-weather-data?city=pancevo

### ✉️ From postman:
  1. Import the collection from the repository
  2. Clone the repository
  3. Add weatherstack api key in local.settings.json
  4. Trigger request "get-weather-from-local-app

## 📔 About the app
  App is created using .NET 8.0, everything is hosted on azure.
  CI/CD pipeline deploys the application to the azure function on push, using github actions.
