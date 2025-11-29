# ---- Build stage ----
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копіюємо csproj
COPY ./lr4_3/lr4_3/lr4_3.csproj ./lr4_3/lr4_3/
COPY ./lr4_3/lr4_3.sln ./

# Restore
RUN dotnet restore lr4_3.sln

# Копіюємо увесь проект
COPY . .

# Publish
RUN dotnet publish ./lr4_3/lr4_3/lr4_3.csproj -c Release -o /app/publish

# ---- Runtime stage ----
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

# Railway використовує порт 8080
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "lr4_3.dll"]