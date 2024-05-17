#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#ARG BUILD_CONFIGURATION=Release
ARG BUILD_CONFIGURATION=runtime
WORKDIR /src
COPY ["Clientes.Api.csproj", "."]
RUN dotnet restore "./Clientes.Api.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./Clientes.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
ARG BUILD_CONFIGURATION=runtime
RUN dotnet publish "./Clientes.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Clientes.Api.dll"]

# docker build -t clientes-api .
# docker run -d -p 3025:80 --name mi-contenedor-clientes-api clientes-api
