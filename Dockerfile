# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копіюємо csproj
COPY ./lr9_mia/lr9_mia.csproj ./lr9_mia/

# Restore
RUN dotnet restore ./lr9_mia/lr9_mia.csproj

# Копіюємо весь проект
COPY ./lr9_mia ./lr9_mia

# Publish
RUN dotnet publish ./lr9_mia/lr9_mia.csproj -c Release -o /app/out


# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/out .

ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "lr9_mia.dll"]