# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# копіюємо репозиторій
COPY . .

# ВАЖЛИВО: переходимо до каталогу проекту
WORKDIR /src/lr4_4/lr4_3

# restore
RUN dotnet restore

# publish
RUN dotnet publish -c Release -o /app

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "lr4_3.dll"]