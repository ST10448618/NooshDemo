# ---------- Build Stage ----------
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy everything
COPY . .

# Restore dependencies
RUN dotnet restore "NooshApp.csproj"

# Publish the application
RUN dotnet publish "NooshApp.csproj" \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false

# ---------- Runtime Stage ----------
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Copy published files
COPY --from=build /app/publish .

# Listen on the Render port
ENV ASPNETCORE_URLS=http://+:10000

EXPOSE 10000

ENTRYPOINT ["dotnet", "NooshApp.dll"]