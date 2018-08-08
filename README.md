# Override configration by Environment variables

This is a sample code that overrides the setting with environment variable using Microsoft.Extensions.Configuration.
For nested settings, environment variable names (Key) are joined by a colon. A colon can not be set as an environment variable name in bash, but it can be used with Dockerfile. In Microsoft.Extensions.Configuration.EnvironmentVariables, you can also use double underscore (__) instead of a colon (:).

## override configration by environment variable

```csharp
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("settings.json")
    .AddEnvironmentVariables("console0_")
```

```Dockerfile
ENV console0_nested:boo1='newvalue2'
ENV console0_nested__boo2='newvalue3'
```

see: https://github.com/aspnet/Configuration/blob/master/src/Config.EnvironmentVariables/EnvironmentVariablesConfigurationProvider.cs#L65


## results

```
docker-compose up --build

... snip ...

console02_1  | dump configuration
console02_1  | nested=
console02_1  | nested:boo2=newvalue3
console02_1  | nested:boo1=newvalue2
console02_1  | foo=bar
console02_console02_1 exited with code 0
```

## see

* [Bash/Zsh - Export environment variable with name containing a colon](https://stackoverflow.com/questions/47827887/bash-zsh-export-environment-variable-with-name-containing-a-colon
)
	> Bash doesn't support such names but you can create them with external programs like env or python.

## MEMO Create Projects

```
dotnet new console -o console02
cd console02
dotnet add package Microsoft.Extensions.Configuration
dotnet add package Microsoft.Extensions.Configuration.EnvironmentVariables
dotnet add package Microsoft.Extensions.Configuration.Json
dotnet new sln
dotnet sln add ./console02.csproj
git init .
devenv ./console02.sln
```
