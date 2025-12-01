# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копіюємо sln
COPY lr4_3/lr4_3.sln ./lr4_3/

# Копіюємо csproj
COPY lr4_3/lr4_3/lr4_3.csproj ./lr4_3/lr4_3/

# Restore
RUN dotnet restore lr4_3/lr4_3.sln

# Копіюємо весь код
COPY . .

# Publish
RUN dotnet publish lr4_3/lr4_3/lr4_3.csproj -c Release -o /app

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "lr4_3.dll"]