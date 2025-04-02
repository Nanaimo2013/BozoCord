FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

# Copy solution and project files
COPY src/*.sln ./
COPY src/BozoCord.API/*.csproj ./BozoCord.API/
COPY src/BozoCord.Core/*.csproj ./BozoCord.Core/
COPY src/BozoCord.Infrastructure/*.csproj ./BozoCord.Infrastructure/

# Restore dependencies
RUN dotnet restore

# Copy the rest of the code
COPY src/. ./

# Build and publish
RUN dotnet publish -c Release -o out

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "BozoCord.API.dll"] 