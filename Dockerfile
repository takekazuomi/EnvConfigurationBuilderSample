FROM microsoft/dotnet:2.1-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY console02.csproj ./
RUN dotnet restore ./console02.csproj
COPY . .
WORKDIR /src/
RUN dotnet build console02.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish console02.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENV console0_nested:boo1='newvalue2'
ENV console0_nested__boo2='newvalue3'

ENTRYPOINT ["dotnet", "console02.dll"]
