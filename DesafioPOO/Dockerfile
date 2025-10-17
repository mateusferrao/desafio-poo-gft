# Use imagem oficial do .NET 9 SDK
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copia csproj e restaura pacotes
COPY *.csproj ./
RUN dotnet restore

# Copia tudo e publica
COPY . ./
RUN dotnet publish -c Release -o out

# Imagem runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "DesafioPOO.dll"]
