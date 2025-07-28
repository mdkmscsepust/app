FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY ["dotnet.API.csproj", "./"]
RUN dotnet restore .
COPY . ./dotnet.API
WORKDIR /app/dotnet.API
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
expose 80
ENTRYPOINT ["dotnet", "dotnet.API.dll"]