# Tranzact Automation Challenge UI
## Getting started
### Prerequisites
- You must have Microsoft (R) Build Engine versión 15.9.21 or higher
- You must have .NET Core 4.8 SDK (v3.1.405) or you could download from here: [Download .Net Core 4.8](https://dotnet.microsoft.com/download/dotnet-framework/thank-you/net48-developer-pack-offline-installer)
- [Gauge](http://getgauge.io/get-started/index.html) or if you have npm you could Install Gauge framework using: 
```
"npm install -g @getgauge/cli"
```
- Finaly execute the following command in prompt
```
gauge install dotnet
```

### build and prepare environment
You must run the following commands to prepare your code to be executed:
```
cd [project_path]
```
dotnet build
```
```
gauge validate
```

### Run tests
```
gauge run specs
```